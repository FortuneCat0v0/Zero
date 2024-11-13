namespace ET.Client
{
    [FriendOf(typeof(ClientKnapsackContainerComponent))]
    [EntitySystemOf(typeof(ClientKnapsackContainerComponent))]
    public static partial class ClientKnapsackContainerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientKnapsackContainerComponent self, int type)
        {
            self.KnapsackContainerType = type;
        }

        [EntitySystem]
        private static void Destroy(this ClientKnapsackContainerComponent self)
        {
            self.KnapsackContainerType = 0;
            self.Items.Clear();
            self.Items = null;
        }

        public static void AddItemFromMessage(this ClientKnapsackContainerComponent self, ItemInfo itemInfo)
        {
            Item item = self.AddChildWithId<Item, int>(itemInfo.Id, itemInfo.ConfigId);
            item.FromMessage(itemInfo);
            self.Items.Add(item.Id, item);
        }

        public static void RemoveItemById(this ClientKnapsackContainerComponent self, long itemId)
        {
            if (!self.Items.TryGetValue(itemId, out EntityRef<Item> itemRef))
            {
                Log.Error($"itemId:{itemId} not found");
                return;
            }

            Item item = itemRef;
            self.Items.Remove(itemId);
            item?.Dispose();
        }

        public static void UpdateItem(this ClientKnapsackContainerComponent self, ItemInfo itemInfo)
        {
            if (!self.Items.TryGetValue(itemInfo.Id, out EntityRef<Item> itemRef))
            {
                Log.Error($"itemId:{itemInfo.Id} not found");
                return;
            }

            Item item = itemRef;
            item.FromMessage(itemInfo);
        }

        public static void Clear(this ClientKnapsackContainerComponent self)
        {
            foreach (Item item in self.Items.Values)
            {
                item?.Dispose();
            }

            self.Items.Clear();
        }
    }
}