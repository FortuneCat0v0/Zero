namespace ET.Server
{
    [FriendOf(typeof(SessionStateComponent))]
    [FriendOf(typeof(SessionPlayerComponent))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2G_LoginGameGateHandler : MessageSessionHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response)
        {
            Scene root = session.Root();

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                return;
            }

            string tokenKey = root.GetComponent<GateSessionKeyComponent>().Get(request.AccountId);
            if (tokenKey == null || !tokenKey.Equals(request.Key))
            {
                response.Error = ErrorCode.ERR_ConnectGateKeyError;
                response.Message = "Gate key验证失败!";
                session.Disconnect().Coroutine();
                return;
            }

            root.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);

            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginGate, request.AccountId.GetHashCode()))
                {
                    if (instanceId != session.InstanceId)
                    {
                        return;
                    }

                    //通知登录中心服 记录本次登录的服务器Zone
                    StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenter;
                    G2L_AddLoginRecord g2LAddLoginRecord = G2L_AddLoginRecord.Create();
                    g2LAddLoginRecord.AccountId = request.AccountId;
                    g2LAddLoginRecord.ServerId = session.Zone();
                    L2G_AddLoginRecord l2GAddLoginRecord =
                            await root.GetComponent<MessageSender>().Call(loginCenterConfig.ActorId, g2LAddLoginRecord) as L2G_AddLoginRecord;

                    if (l2GAddLoginRecord.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = l2GAddLoginRecord.Error;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    SessionStateComponent SessionStateComponent = session.GetComponent<SessionStateComponent>();
                    if (SessionStateComponent == null)
                    {
                        SessionStateComponent = session.AddComponent<SessionStateComponent>();
                    }

                    SessionStateComponent.State = SessionState.Normal;

                    PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
                    Player player = playerComponent.Get(request.AccountId);

                    if (player == null)
                    {
                        // 添加一个新的GateUnit
                        // Player与Unit的Id都等于RoleId
                        player = playerComponent.AddChildWithId<Player, long>(request.RoleId, request.AccountId);
                        player.PlayerState = PlayerState.Gate;
                        playerComponent.Add(player);

                        PlayerSessionComponent playerSessionComponent = player.AddComponent<PlayerSessionComponent>();
                        playerSessionComponent.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.GateSession);
                        await playerSessionComponent.AddLocation(LocationType.GateSession);

                        player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
                        await player.AddLocation(LocationType.Player);

                        playerSessionComponent.Session = session;
                    }
                    else
                    {
                        PlayerSessionComponent playerSessionComponent = player.GetComponent<PlayerSessionComponent>();
                        playerSessionComponent.Session = session;

                        player.RemoveComponent<PlayerOfflineOutTimeComponent>();
                    }

                    session.AddComponent<SessionPlayerComponent>().Player = player;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}