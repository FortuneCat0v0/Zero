namespace ET
{
    [FriendOf(typeof(Item))]
    [EntitySystemOf(typeof(Item))]
    public static partial class ItemSystem
    {
        [EntitySystem]
        private static void Awake(this Item self, int configId)
        {
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void Destroy(this Item self)
        {
            self.ConfigId = 0;
            self.ContainerType = 0;
            self.Num = 0;
            self.AttributeEntryIds.Clear();
            self.AttributeEntryIds = null;
        }

        public static ItemInfo ToMessage(this Item self)
        {
            ItemInfo itemInfo = ItemInfo.Create();
            itemInfo.Id = self.Id;
            itemInfo.ConfigId = self.ConfigId;
            itemInfo.ContainerType = self.ContainerType;
            itemInfo.Num = self.Num;
            foreach (long id in self.AttributeEntryIds)
            {
                itemInfo.AttributeEntryInfos.Add(self.GetChild<AttributeEntry>(id).ToMessage());
            }

            return itemInfo;
        }

        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.ConfigId = itemInfo.ConfigId;
            self.ContainerType = itemInfo.ContainerType;
            self.Num = itemInfo.Num;
            foreach (AttributeEntryInfo attributeEntryInfo in itemInfo.AttributeEntryInfos)
            {
                AttributeEntry attributeEntry = self.AddChildWithId<AttributeEntry>(attributeEntryInfo.Id);
                attributeEntry.FromMessage(attributeEntryInfo);
                self.AttributeEntryIds.Add(attributeEntryInfo.Id);
            }
        }
    }
}