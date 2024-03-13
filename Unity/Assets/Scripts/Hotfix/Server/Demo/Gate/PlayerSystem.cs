namespace ET.Server
{
    [EntitySystemOf(typeof(Player))]
    [FriendOf(typeof(Player))]
    public static partial class PlayerSystem
    {
        [EntitySystem]
        private static void Awake(this Player self, string a)
        {
            self.Account = a;
        }

        [EntitySystem]
        private static void Awake(this Player self, long acountId)
        {
            self.AccountId = acountId;
        }
    }
}