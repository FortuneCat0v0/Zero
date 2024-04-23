namespace ET.Server
{
    public enum PlayerState
    {
        Disconnect,
        Gate,
        Game,
    }

    [ChildOf(typeof(PlayerComponent))]
    public sealed class Player : Entity, IAwake<string>, IAwake<long>
    {
        public string Account { get; set; }
        public long AccountId { get; set; }
        public PlayerState PlayerState { get; set; }
    }
}