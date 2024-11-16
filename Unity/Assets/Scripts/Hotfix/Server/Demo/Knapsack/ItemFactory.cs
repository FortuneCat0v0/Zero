namespace ET.Server
{
    public static class ItemFactory
    {
        public static Item CreateItem(KnapsackContainerComponent parent, int configId)
        {
            if (!ItemConfigCategory.Instance.DataMap.ContainsKey(configId))
            {
                Log.Error($"当前所创建的物品ID不存在：{configId}");
            }

            Item item = parent.AddChild<Item, int>(configId);
            item.ContainerType = parent.KnapsackContainerType;

            return item;
        }
    }
}