namespace ET
{
    public enum RoleState
    {
        Normal = 0,
        Freeze,
    }

    public enum ServerStatus
    {
        Normal = 0,
        Stop = 1,
    }

    public enum PlayerState
    {
        Disconnect,
        Gate,
        Game,
    }

    public enum ItemType
    {
        Equipment,
        Material,
        Consume
    }

    public enum ItemOpType
    {
        Add,
        Remove,
    }

    public enum ItemContainerType
    {
        Bag = 0,
        Role = 1,
    }

    public enum EntryType
    {
        Common = 1, //普通词条
        Special = 2, //特殊词条
    }
}