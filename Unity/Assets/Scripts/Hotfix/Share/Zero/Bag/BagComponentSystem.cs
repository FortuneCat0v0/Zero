﻿using System.Collections.Generic;
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
            foreach (Entity entity in self.Children.Values)
            {
                self.ItemsDict.Add(entity.Id, entity as Item);
            }
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (self.ItemsDict.ContainsKey(item.Id))
            {
                return false;
            }

            self.ItemsDict.Add(item.Id, item);
            self.AddChild(item);
            return true;
        }

        public static bool RemoveItem(this BagComponent self, long id)
        {
            if (!self.ItemsDict.ContainsKey(id))
            {
                return false;
            }

            Item item = self.ItemsDict[id];
            item.Dispose();
            self.ItemsDict.Remove(id);
            return true;
        }

        public static Item RemoveItemNoDispose(this BagComponent self, long id)
        {
            if (!self.ItemsDict.ContainsKey(id))
            {
                return null;
            }

            Item item = self.ItemsDict[id];
            self.ItemsDict.Remove(id);
            return item;
        }

        public static Item GetItem(this BagComponent self, long id)
        {
            if (!self.ItemsDict.ContainsKey(id))
            {
                return null;
            }

            return self.ItemsDict[id];
        }

        public static List<Item> GetAllItems(this BagComponent self)
        {
            List<Item> items = new List<Item>();
            foreach (Item item in self.ItemsDict.Values)
            {
                items.Add(item);
            }

            return items;
        }

        public static void Clear(this BagComponent self)
        {
            foreach (Item item in self.ItemsDict.Values)
            {
                item.Dispose();
            }

            self.ItemsDict.Clear();
        }
    }
}