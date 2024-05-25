namespace ET.Server
{
    [FriendOf(typeof (LoginInfoRecordComponent))]
    [EntitySystemOf(typeof (LoginInfoRecordComponent))]
    public static partial class LoginInfoRecordComponentSystem
    {
        [EntitySystem]
        private static void Awake(this LoginInfoRecordComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this LoginInfoRecordComponent self)
        {
            self.AccountLoginInfoDict.Clear();
        }

        public static void Add(this LoginInfoRecordComponent self, long key, int value)
        {
            if (self.AccountLoginInfoDict.ContainsKey(key))
            {
                self.AccountLoginInfoDict[key] = value;
                return;
            }

            self.AccountLoginInfoDict.Add(key, value);
        }

        public static void Remove(this LoginInfoRecordComponent self, long key)
        {
            if (self.AccountLoginInfoDict.ContainsKey(key))
            {
                self.AccountLoginInfoDict.Remove(key);
            }
        }

        public static int Get(this LoginInfoRecordComponent self, long key)
        {
            if (!self.AccountLoginInfoDict.TryGetValue(key, out int value))
            {
                return -1;
            }

            return value;
        }

        public static bool IsExist(this LoginInfoRecordComponent self, long key)
        {
            return self.AccountLoginInfoDict.ContainsKey(key);
        }
    }
}