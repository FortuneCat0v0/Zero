using System;
using System.Collections.Generic;

namespace ET.Client
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

            EventSystem.Instance.Publish(self.Root(), new ChangeEquipItem());
            
            return true;
        }

        public static void RemoveEquipItem(this EquipmentComponent self, EquipPosition equipPosition)
        {
            if (self.EquipItemsDict[(int)equipPosition] == 0)
            {
                return;
            }

            Item item = self.GetChild<Item>(self.EquipItemsDict[(int)equipPosition]);
            self.EquipItemsDict[(int)equipPosition] = 0;

            item.Dispose();

            EventSystem.Instance.Publish(self.Root(), new ChangeEquipItem());
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

