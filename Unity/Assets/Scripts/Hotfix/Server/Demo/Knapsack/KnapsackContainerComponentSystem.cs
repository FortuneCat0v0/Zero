namespace ET.Server
{
    [FriendOf(typeof(KnapsackContainerComponent))]
    [EntitySystemOf(typeof(KnapsackContainerComponent))]
    public static partial class KnapsackContainerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this KnapsackContainerComponent self, int type)
        {
            self.KnapsackContainerType = type;
        }

        [EntitySystem]
        private static void Destroy(this KnapsackContainerComponent self)
        {
            self.Items.Clear();
            self.KnapsackContainerType = (int)KnapsackContainerType.None;
        }

        [EntitySystem]
        private static void Deserialize(this KnapsackContainerComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                if (entity is Item item)
                {
                    self.Items.Add(item.Id, item);
                }
            }
        }

        public static void GetItems(this KnapsackContainerComponent self, ListComponent<Item> itemList)
        {
            foreach (Item item in self.Items.Values)
            {
                itemList.Add(item);
            }
        }

        public static Item GetItem(this KnapsackContainerComponent self, long itemId)
        {
            self.Items.TryGetValue(itemId, out EntityRef<Item> item);
            return item;
        }

        public static void AddItem(this KnapsackContainerComponent self, Item item)
        {
            if (item.Parent != self)
            {
                self.AddChild(item);
            }

            if (self.Items.ContainsKey(item.Id))
            {
                return;
            }

            self.Items.Add(item.Id, item);
            ItemNoticeHelper.SyncItemInfo(self.Parent.GetParent<Unit>(), item, ItemOpType.Add);
        }

        public static bool RemoveItem(this KnapsackContainerComponent self, long itemId)
        {
            if (!self.Items.TryGetValue(itemId, out EntityRef<Item> itemRef))
            {
                return false;
            }

            Item item = itemRef;
            self.Items.Remove(itemId);
            ItemNoticeHelper.SyncItemInfo(self.Parent.GetParent<Unit>(), item, ItemOpType.Remove);
            item?.Dispose();

            return true;
        }
    }
}