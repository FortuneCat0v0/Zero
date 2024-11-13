using System.Collections.Generic;

namespace ET
{
    public struct ItemInfoChange
    {
        public ItemInfo ItemInfo;
    }

    public enum ItemOpType
    {
        Add,
        Remove,
        Update,
    }

    public enum KnapsackContainerType
    {
        None = 0, //无类型
        Inventory = 1, //随身背包
        Warehouse = 2, //仓库背包
    }

    [ChildOf]
    public class Item : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId { get; set; }

        public int ContainerType { get; set; }

        public int Num { get; set; }

        public List<long> AttributeEntryIds { get; set; } = new();

        public ItemConfig ItemConfig => ItemConfigCategory.Instance.Get(this.ConfigId);
    }
}