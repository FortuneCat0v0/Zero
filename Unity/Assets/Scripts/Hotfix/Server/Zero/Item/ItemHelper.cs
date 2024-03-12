using System;
using System.Collections.Generic;

namespace ET.Server
{
    public static class ItemHelper
    {
        /// <summary>
        /// 注意！！！将Item从一个容器转移到另一个容器时，先新容器AddItem，再旧容器RemoveItem
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
                case ItemContainerType.Role:
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
                case ItemContainerType.Role:
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
                case ItemContainerType.Role:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = itemInfo;
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Remove;
            m2CItemUpdateOp.ItemContainerType = (int)itemContainerType;
        }

        public static void SyncAllItems(Unit unit, ItemContainerType itemContainerType)
        {
            List<Item> items = null;
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    items = unit.GetComponent<BagComponent>().GetAllItems();
                    break;
                case ItemContainerType.Role:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            M2C_AllItems m2CAllItems = M2C_AllItems.Create();
            m2CAllItems.ItemContainerType = (int)itemContainerType;
            foreach (Item item in items)
            {
                m2CAllItems.ItemInfos.Add(item.ToMessage());
            }

            MapMessageHelper.SendToClient(unit, m2CAllItems);
        }
    }
}