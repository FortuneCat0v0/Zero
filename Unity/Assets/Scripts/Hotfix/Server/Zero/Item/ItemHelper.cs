using System;
using System.Collections.Generic;

namespace ET.Server
{
    public static class ItemHelper
    {
        public static Item GetItem(Unit unit, long itemId, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    return unit.GetComponent<BagComponent>().GetItem(itemId);
                case ItemContainerType.Equipment:
                    return unit.GetComponent<EquipmentComponent>().GetEquipItemById(itemId);
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }
        }

        /// <summary>
        /// 注意！！！将Item从一个容器转移到另一个容器时，先新容器AddItem，再旧容器RemoveItemNoDispose
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="item"></param>
        /// <param name="itemContainerType"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void AddItem(Unit unit, Item item, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    if (!unit.GetComponent<BagComponent>().AddItem(item))
                    {
                        return;
                    }

                    break;
                case ItemContainerType.Equipment:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Add;
            m2CItemUpdateOp.ItemContainerType = (int)itemContainerType;
            MapMessageHelper.SendToClient(unit, m2CItemUpdateOp);
        }

        public static void AddItem(Scene root, Unit unit, int itemConfig, ItemContainerType itemContainerType)
        {
            Item item = ItemFactory.Create(root, itemConfig);
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    if (!unit.GetComponent<BagComponent>().AddItem(item))
                    {
                        item.Dispose();
                        return;
                    }

                    break;
                case ItemContainerType.Equipment:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Add;
            m2CItemUpdateOp.ItemContainerType = (int)itemContainerType;
            MapMessageHelper.SendToClient(unit, m2CItemUpdateOp);
        }

        public static void RemoveItem(Unit unit, long id, ItemContainerType itemContainerType)
        {
            ItemInfo itemInfo = null;

            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    BagComponent bagComponent = unit.GetComponent<BagComponent>();
                    Item item = bagComponent.GetItem(id);

                    if (item == null)
                    {
                        return;
                    }

                    itemInfo = item.ToMessage();
                    if (!unit.GetComponent<BagComponent>().RemoveItem(id))
                    {
                        return;
                    }

                    break;
                case ItemContainerType.Equipment:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = itemInfo;
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Remove;
            m2CItemUpdateOp.ItemContainerType = (int)itemContainerType;
        }
    }
}