namespace ET;

public static class ItemFactory
{
    public static Item Create(Scene root, ItemInfo itemInfo)
    {
        Item item = root.AddChildWithId<Item>(itemInfo.Id);
        item.FromMessage(itemInfo);
        return item;
    }

    public static Item Create(Scene root, int configId)
    {
        Item item = root.AddChild<Item, int>(configId);
        AddComponentByItemType(item);
        return item;
    }

    public static void AddComponentByItemType(Item item)
    {
    }
}