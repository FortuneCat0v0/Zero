namespace ET
{
    public enum ServerStatus
    {
        Normal = 0,
        Stop = 1,
    }

    [ChildOf]
    public class GameServer : Entity, IAwake
    {
        public int Status;
        public string ServerName;
    }
}