namespace ET
{
    [FriendOf(typeof(GameServer))]
    public static class ServerSystem
    {
        public static ServerInfo ToMessage(this GameServer self)
        {
            ServerInfo serverInfo = ServerInfo.Create();
            serverInfo.Id = self.Id;
            serverInfo.ServerName = self.ServerName;
            serverInfo.Status = self.Status;
            return serverInfo;
        }

        public static void FromMessage(this GameServer self, ServerInfo serverInfo)
        {
            self.ServerName = serverInfo.ServerName;
            self.Status = serverInfo.Status;
        }
    }
}