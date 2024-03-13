namespace ET.Server
{
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_LoginRealmHandler : MessageSessionHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response)
        {
            Scene root = session.Root();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            string token = root.GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.RealmTokenKey)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect().Coroutine();
                return;
            }

            root.GetComponent<TokenComponent>().Remove(request.AccountId);

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginRealm, request.AccountId))
                {
                    // 取模固定分配一个Gate
                    StartSceneConfig startSceneConfig = RealmGateAddressHelper.GetGate(session.Zone(), request.AccountId);

                    // 向gate请求一个key,客户端可以拿着这个key连接gate
                    R2G_GetLoginGateKey r2GGetLoginGateKey = R2G_GetLoginGateKey.Create();
                    r2GGetLoginGateKey.AccountId = request.AccountId;
                    G2R_GetLoginGateKey g2RGetLoginGateKey = await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId,
                        r2GGetLoginGateKey) as G2R_GetLoginGateKey;

                    if (g2RGetLoginGateKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = g2RGetLoginGateKey.Error;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    response.GateSessionKey = g2RGetLoginGateKey.GateSessionKey;
                    response.GateAddress = startSceneConfig.OuterIPPort.ToString();
                }
            }

            session.Disconnect().Coroutine();
        }
    }
}