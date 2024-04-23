namespace ET
{
    public enum RoleState
    {
        Normal = 0,
        Freeze,
    }

    [ChildOf]
    public class Role : Entity, IAwake
    {
        public string Name;

        public int ServerId;

        public int State;

        public long AccountId;

        public long LastLoginTime;

        public long CreateTime;
    }
}