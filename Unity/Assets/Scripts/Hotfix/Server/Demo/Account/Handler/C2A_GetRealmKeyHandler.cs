namespace ET.Server
{
    [MessageSessionHandler(SceneType.Account)]
    public class C2A_GetRealmKeyHandler : MessageSessionHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response)
        {
            Scene root = session.Root();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            string token = root.GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccountId))
                {
                    StartSceneConfig realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);

                    A2R_GetRealmKey a2RGetRealmKey = A2R_GetRealmKey.Create();
                    a2RGetRealmKey.AccountId = request.AccountId;
                    R2A_GetRealmKey r2AGetRealmKey =
                            await root.GetComponent<MessageSender>().Call(realmStartSceneConfig.ActorId, a2RGetRealmKey) as R2A_GetRealmKey;

                    if (r2AGetRealmKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = r2AGetRealmKey.Error;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    response.RealmKey = r2AGetRealmKey.RealmKey;
                    response.RealmAddress = realmStartSceneConfig.OuterIPPort.ToString();
                }
            }

            // 结束与Account的连接
            session.Disconnect().Coroutine();
        }
    }
}