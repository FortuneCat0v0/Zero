using System.Collections.Generic;
using System.Linq;

namespace ET
{
    [FriendOf(typeof(BagComponent))]
    [EntitySystemOf(typeof(BagComponent))]
    public static partial class BagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BagComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BagComponent self)
        {
            // foreach (Entity entity in self.Children.Values)
            // {
            //     
            // }
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (self.ItemIds.Contains(item.Id))
            {
                Log.Error($"BagComponent.ItemIds 已存在相同 Id:{item.Id}");
                return false;
            }

            self.ItemIds.Add(item.Id);
            self.AddChild(item);
            return true;
        }

        public static bool RemoveItem(this BagComponent self, long id)
        {
            if (!self.ItemIds.Contains(id))
            {
                Log.Error($"BagComponent.ItemIds 不存在 Id:{id}");
                return false;
            }

            Item item = self.GetChild<Item>(id);
            item?.Dispose();
            self.ItemIds.Remove(id);
            return true;
        }

        public static Item GetItem(this BagComponent self, long id)
        {
            if (!self.ItemIds.Contains(id))
            {
                Log.Error($"BagComponent.ItemIds 不存在 Id:{id}");
                return null;
            }

            return self.GetChild<Item>(id);
        }

        public static List<Item> GetAllItems(this BagComponent self)
        {
            return self.Children.Values.Select(entity => entity as Item).ToList();
        }

        public static void RemoveAllItems(this BagComponent self)
        {
            foreach (long id in self.ItemIds)
            {
                Item item = self.GetChild<Item>(id);
                item.Dispose();
            }

            self.ItemIds.Clear();
        }
    }
}