namespace ET
{
    [FriendOf(typeof(AttributeEntry))]
    [EntitySystemOf(typeof(AttributeEntry))]
    public static partial class AttributeEntrySystem
    {
        [EntitySystem]
        private static void Awake(this AttributeEntry self)
        {
        }

        public static AttributeEntryInfo ToMessage(this AttributeEntry self)
        {
            AttributeEntryInfo attributeEntryInfo = AttributeEntryInfo.Create();
            attributeEntryInfo.Key = self.Key;
            attributeEntryInfo.Value = self.Value;
            attributeEntryInfo.EntryType = (int)self.EntryType;

            return attributeEntryInfo;
        }

        public static void FromMessage(this AttributeEntry self, AttributeEntryInfo attributeEntryInfo)
        {
            self.Key = attributeEntryInfo.Key;
            self.Value = attributeEntryInfo.Value;
            self.EntryType = (EntryType)attributeEntryInfo.EntryType;
        }
    }
}