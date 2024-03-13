namespace ET.Server
{
    [FriendOf(typeof (AccountSessionComponent))]
    [EntitySystemOf(typeof (AccountSessionComponent))]
    public static partial class AccountSessionComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AccountSessionComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this AccountSessionComponent self)
        {
            self.AccountSessionDictionary.Clear();
        }

        public static long Get(this AccountSessionComponent self, long accountId)
        {
            if (!self.AccountSessionDictionary.TryGetValue(accountId, out long sessionId))
            {
                return 0;
            }

            return sessionId;
        }

        public static void Add(this AccountSessionComponent self, long accountId, long sessionId)
        {
            if (self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary[accountId] = sessionId;
                return;
            }

            self.AccountSessionDictionary.Add(accountId, sessionId);
        }

        public static void Remove(this AccountSessionComponent self, long accountId)
        {
            if (self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary.Remove(accountId);
            }
        }
    }
}