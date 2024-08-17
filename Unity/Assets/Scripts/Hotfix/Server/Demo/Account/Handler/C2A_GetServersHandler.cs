namespace ET.Server
{
    [FriendOf(typeof(GameServerComponent))]
    [MessageSessionHandler(SceneType.Account)]
    public class C2A_GetServersHandler : MessageSessionHandler<C2A_GetServers, A2C_GetServers>
    {
        protected override async ETTask Run(Session session, C2A_GetServers request, A2C_GetServers response)
        {
            Scene root = session.Root();

            string token = root.GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect().Coroutine();
                return;
            }

            foreach (GameServer server in root.GetComponent<GameServerComponent>().GameServers)
            {
                response.ServerInfos.Add(server.ToMessage());
            }

            await ETTask.CompletedTask;
        }
    }
}