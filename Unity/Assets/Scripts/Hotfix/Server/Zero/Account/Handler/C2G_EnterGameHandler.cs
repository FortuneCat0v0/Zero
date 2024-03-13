using System;

namespace ET.Server
{
    [FriendOf(typeof(SessionStateComponent))]
    [FriendOf(typeof(SessionPlayerComponent))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_EnterGameHandler : MessageSessionHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response)
        {
            Scene root = session.Root();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                return;
            }

            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (sessionPlayerComponent == null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                return;
            }

            Player player = sessionPlayerComponent.Player;

            if (player == null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePlayerError;
                return;
            }

            long instanceId = session.InstanceId;

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginGate, player.AccountId.GetHashCode()))
                {
                    if (instanceId != session.InstanceId || player.IsDisposed)
                    {
                        response.Error = ErrorCode.ERR_PlayerSessionError;
                        return;
                    }

                    if (session.GetComponent<SessionStateComponent>() != null &&
                        session.GetComponent<SessionStateComponent>().State == SessionState.Game)
                    {
                        response.Error = ErrorCode.ERR_SessionStateError;
                        return;
                    }

                    // Player在线，则直接进入
                    if (player.PlayerState == PlayerState.Game)
                    {
                        try
                        {
                            M2G_RequestEnterGameState m2GRequestEnterGameState = await root.GetComponent<MessageLocationSenderComponent>()
                                    .Get(LocationType.Unit).Call(player.Id, G2M_RequestEnterGameState.Create()) as M2G_RequestEnterGameState;
                            if (m2GRequestEnterGameState.Error == ErrorCode.ERR_Success)
                            {
                                response.MyId = player.Id;
                                return;
                            }

                            Log.Error("二次登录失败  " + m2GRequestEnterGameState.Error + " | " + m2GRequestEnterGameState.Message);
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            session.Disconnect().Coroutine();
                        }
                        catch (Exception e)
                        {
                            Log.Error("二次登录失败  " + e.ToString());
                            response.Error = ErrorCode.ERR_ReEnterGameError2;
                            await DisconnectHelper.KickPlayer(player, true);
                            session.Disconnect().Coroutine();
                            throw;
                        }

                        return;
                    }

                    try
                    {
                        // 从数据库或者缓存中加载出Unit实体及其相关组件
                        (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);

                        // 存储Player的InstanceId，当从服务器通过Unit发消息给客户端时，先发送给网关上对应的Player，
                        // 再通过Player上引用的ClientSession转发给客户端(SessionStreamDispatcherServerInner)
                        // unit.AddComponent<UnitGateComponent, long>(player.InstanceId);

                        // player.ChatInfoInstanceId = await this.EnterWorldChatServer(unit); //登录聊天服
                        // player.MatchInfoInstanceId = await this.EnterMatchServer(unit); // 登录匹配服

                        //玩家Unit上线后的初始化操作
                        await UnitHelper.InitUnit(unit, isNewPlayer);
                        response.MyId = player.Id;

                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map1");

                        TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();

                        SessionStateComponent SessionStateComponent = session.GetComponent<SessionStateComponent>();
                        if (SessionStateComponent == null)
                        {
                            SessionStateComponent = session.AddComponent<SessionStateComponent>();
                        }

                        SessionStateComponent.State = SessionState.Game;

                        player.PlayerState = PlayerState.Game;
                    }
                    catch (Exception e)
                    {
                        Log.Error($"角色进入游戏逻辑服出现问题 账号Id: {player.AccountId}  角色Id: {player.Id}   异常信息： {e.ToString()}");
                        response.Error = ErrorCode.ERR_EnterGameError;
                        await DisconnectHelper.KickPlayer(player, true);
                        session.Disconnect().Coroutine();
                    }
                }
            }
        }

        // private async ETTask<long> EnterWorldChatServer(Unit unit)
        // {
        //     StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "ChatInfo");
        //     Chat2G_EnterChat chat2GEnterChat = (Chat2G_EnterChat)await MessageHelper.CallActor(startSceneConfig.InstanceId,
        //         new G2Chat_EnterChat()
        //         {
        //             UnitId = unit.Id,
        //             Name = unit.GetComponent<RoleInfo>().Name,
        //             GateSessionActorId = unit.GetComponent<UnitGateComponent>().GateSessionActorId
        //         });
        //
        //     return chat2GEnterChat.ChatInfoUnitInstanceId;
        // }
    }
}