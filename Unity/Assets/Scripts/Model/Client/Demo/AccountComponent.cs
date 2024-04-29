namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class AccountComponent : Entity, IAwake
    {
        public string Token { get; set; }
        public long AccountId { get; set; }
        public string RealmKey { get; set; }
        public string RealmAddress { get; set; }
    }
}