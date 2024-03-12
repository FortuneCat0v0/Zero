namespace ET
{
    [FriendOf(typeof(Item))]
    [EntitySystemOf(typeof(Item))]
    public static partial class ItemSystem
    {
        [EntitySystem]
        private static void Awake(this Item self)
        {
        }

        [EntitySystem]
        private static void Awake(this Item self, int configId)
        {
            self.ItemConfigId = configId;
        }

        public static ItemInfo ToMessage(this Item self)
        {
            ItemInfo itemInfo = ItemInfo.Create();
            itemInfo.Id = self.Id;
            itemInfo.ItemConfigId = self.ItemConfigId;

            return itemInfo;
        }

        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.ItemConfigId = itemInfo.ItemConfigId;
        }
    }
}