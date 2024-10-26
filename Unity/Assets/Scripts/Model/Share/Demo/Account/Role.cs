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
        public string Name { get; set; }

        public int ServerId { get; set; }

        public int State { get; set; }

        public long AccountId { get; set; }

        public long LastLoginTime { get; set; }

        public long CreateTime { get; set; }
    }
}