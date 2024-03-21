using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(EquipmentComponent))]
    [EntitySystemOf(typeof(EquipmentComponent))]
    public static partial class EquipmentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this EquipmentComponent self)
        {
            foreach (EquipPosition equipPosition in Enum.GetValues(typeof(EquipPosition)))
            {
                if (self.EquipItemsDict.ContainsKey((int)equipPosition))
                {
                    continue;
                }

                self.EquipItemsDict.Add((int)equipPosition, 0);
            }
        }
        
        public static bool IsEquipItemByPosition(this EquipmentComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItemsDict[(int)equipPosition] == 0)
            {
                return false;
            }

            return true;
        }

        public static bool EquipItem(this EquipmentComponent self, EquipPosition equipPosition, Item item)
        {
            if (self.EquipItemsDict[(int)equipPosition] != 0)
            {
                return false;
            }

            self.AddChild(item);
            self.EquipItemsDict[(int)equipPosition] = item.Id;

            EventSystem.Instance.Publish(self.Root(),
                new ChangeEquipItem() { Unit = self.GetParent<Unit>(), Item = item, EquipPosition = equipPosition, EquipOp = EquipOp.Load });

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Add;
            m2CItemUpdateOp.ItemContainerType = (int)ItemContainerType.Equipment;
            m2CItemUpdateOp.EquipPosition = (int)equipPosition;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2CItemUpdateOp);

            return true;
        }

        /// <summary>
        /// 注意！服务端Remove只是移除引用，并不会Dispose,请Remove后Add或Dispose!!!
        /// </summary>
        /// <param name="self"></param>
        /// <param name="equipPosition"></param>
        /// <returns></returns>
        public static Item UnloadEquipItem(this EquipmentComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItemsDict[(int)equipPosition] == 0)
            {
                return null;
            }

            Item item = self.GetChild<Item>(self.EquipItemsDict[(int)equipPosition]);
            self.EquipItemsDict[(int)equipPosition] = 0;

            EventSystem.Instance.Publish(self.Root(),
                new ChangeEquipItem() { Unit = self.GetParent<Unit>(), Item = item, EquipPosition = equipPosition, EquipOp = EquipOp.Unload });

            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)ItemOpType.Remove;
            m2CItemUpdateOp.ItemContainerType = (int)ItemContainerType.Equipment;
            m2CItemUpdateOp.EquipPosition = (int)equipPosition;
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2CItemUpdateOp);

            return item;
        }

        public static Item GetEquipItemByPosition(this EquipmentComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItemsDict[(int)equipPosition] == 0)
            {
                return null;
            }

            Item item = self.GetChild<Item>(self.EquipItemsDict[(int)equipPosition]);

            return item;
        }

        public static Item GetEquipItemById(this EquipmentComponent self, long id)
        {
            Item item = self.GetChild<Item>(id);

            return item;
        }

        public static Dictionary<int, Item> GetAllItems(this EquipmentComponent self)
        {
            Dictionary<int, Item> itemsDict = new Dictionary<int, Item>();

            foreach (KeyValuePair<int, long> keyValuePair in self.EquipItemsDict)
            {
                if (keyValuePair.Value == 0)
                {
                    continue;
                }

                Item item = self.GetChild<Item>(keyValuePair.Value);
                itemsDict.Add(keyValuePair.Key, item);
            }

            return itemsDict;
        }

        public static void Clear(this EquipmentComponent self)
        {
            foreach (KeyValuePair<int, long> keyValuePair in self.EquipItemsDict)
            {
                if (keyValuePair.Value == 0)
                {
                    continue;
                }

                Item item = self.GetChild<Item>(keyValuePair.Value);
                item.Dispose();
            }
            
            foreach (EquipPosition equipPosition in Enum.GetValues(typeof(EquipPosition)))
            {
                self.EquipItemsDict[(int)equipPosition] = 0;
            }
        }
    }
}

