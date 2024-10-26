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
                            M2G_RequestEnterGame m2GRequestEnterGame =
                                    await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit)
                                            .Call(player.Id, G2M_RequestEnterGame.Create()) as M2G_RequestEnterGame;
                            if (m2GRequestEnterGame.Error == ErrorCode.ERR_Success)
                            {
                                response.MyId = player.Id;
                                return;
                            }

                            Log.Error("二次登录失败  " + m2GRequestEnterGame.Error + " | " + m2GRequestEnterGame.Message);
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            session.Disconnect().Coroutine();
                        }
                        catch (Exception e)
                        {
                            Log.Error("二次登录失败  " + e);
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

                        await this.EnterWorldChatServer(unit); //登录聊天服
                        // player.MatchInfoInstanceId = await this.EnterMatchServer(unit); // 登录匹配服

                        // WorkFlow 玩家Unit上线后的初始化操作
                        // unit.GetComponent<NumericComponent>().SetNoEvent(NumericType.MaxBagCapacity, 30);

                        response.MyId = player.Id;

                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map1");

                        TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();

                        SessionStateComponent SessionStateComponent =
                                session.GetComponent<SessionStateComponent>() ?? session.AddComponent<SessionStateComponent>();

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

        private async ETTask EnterWorldChatServer(Unit unit)
        {
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "Chat");
            G2Chat_EnterChat request = G2Chat_EnterChat.Create();
            request.UnitId = unit.Id;
            request.Name = unit.RoleName;

            await unit.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, request);
        }
    }
}