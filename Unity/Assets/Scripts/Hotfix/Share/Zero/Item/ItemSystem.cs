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
            self.ConfigId = configId;
        }

        public static ItemInfo ToMessage(this Item self)
        {
            ItemInfo itemInfo = ItemInfo.Create();
            itemInfo.Id = self.Id;
            itemInfo.ConfigId = self.ConfigId;
            foreach (long id in self.AttributeEntryIds)
            {
                itemInfo.AttributeEntryInfos.Add(self.GetChild<AttributeEntry>(id).ToMessage());
            }

            return itemInfo;
        }

        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.ConfigId = itemInfo.ConfigId;
            foreach (AttributeEntryInfo attributeEntryInfo in itemInfo.AttributeEntryInfos)
            {
                AttributeEntry attributeEntry = self.AddChildWithId<AttributeEntry>(attributeEntryInfo.Id);
                attributeEntry.FromMessage(attributeEntryInfo);
                self.AttributeEntryIds.Add(attributeEntryInfo.Id);
            }
        }
    }
}