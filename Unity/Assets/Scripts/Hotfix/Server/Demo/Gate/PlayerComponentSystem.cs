namespace ET.Server
{
    [FriendOf(typeof(PlayerComponent))]
    public static partial class PlayerComponentSystem
    {
        public static void Add(this PlayerComponent self, Player player)
        {
            self.dictionary.Add(player.AccountId, player);
        }

        public static void Remove(this PlayerComponent self, Player player)
        {
            self.dictionary.Remove(player.AccountId);
            player.Dispose();
        }

        public static Player Get(this PlayerComponent self, long accountId)
        {
            self.dictionary.TryGetValue(accountId, out EntityRef<Player> player);
            return player;
        }
    }
}