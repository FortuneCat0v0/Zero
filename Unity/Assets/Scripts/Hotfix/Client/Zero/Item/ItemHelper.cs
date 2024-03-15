using System;
using System.Collections.Generic;

namespace ET.Client
{
    public static class ItemHelper
    {
        public static void Clear(Scene root, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    root.GetComponent<BagComponent>().Clear();
                    break;
                case ItemContainerType.Role:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }
        }

        public static Item GetItem(Scene root, long itemId, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    return root.GetComponent<BagComponent>().GetItem(itemId);
                case ItemContainerType.Role:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            return null;
        }

        public static List<Item> GetAllItem(Scene root, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    return root.GetComponent<BagComponent>().GetAllItems();
                case ItemContainerType.Role:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }

            return null;
        }

        public static void AddItem(Scene root, Item item, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    if (!root.GetComponent<BagComponent>().AddItem(item))
                    {
                        item.Dispose();
                    }

                    break;
                case ItemContainerType.Role:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }
        }

        public static void RemoveItem(Scene root, long itemId, ItemContainerType itemContainerType)
        {
            switch (itemContainerType)
            {
                case ItemContainerType.Bag:
                    root.GetComponent<BagComponent>().RemoveItem(itemId);
                    break;
                case ItemContainerType.Role:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemContainerType), itemContainerType, null);
            }
        }
    }
}