using System;

namespace ET
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

            return true;
        }

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
    }
}