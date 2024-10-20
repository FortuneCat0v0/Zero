namespace ET.Server
{
    [FriendOf(typeof(LRUNode))]
    [EntitySystemOf(typeof(LRUNode))]
    public static partial class LRUNodeSystem
    {
        [EntitySystem]
        private static void Awake(this LRUNode self, long key)
        {
            self.Key = key;
        }

        [EntitySystem]
        private static void Destroy(this LRUNode self)
        {
            self.Key = 0;
            self.Frequency = 0;
        }
    }
}