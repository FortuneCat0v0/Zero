using System;

namespace ET.Server
{
    [FriendOf(typeof(UnitCache))]
    [FriendOf(typeof(UnitCacheComponent))]
    [EntitySystemOf(typeof(UnitCacheComponent))]
    public static partial class UnitCacheComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UnitCacheComponent self)
        {
            self.UnitCacheKeys.Clear();
            foreach (Type type in CodeTypes.Instance.GetTypes().Values)
            {
                if (type != typeof(IUnitCache) && typeof(IUnitCache).IsAssignableFrom(type))
                {
                    self.UnitCacheKeys.Add(type.Name);
                }
            }

            foreach (string key in self.UnitCacheKeys)
            {
                UnitCache unitCache = self.AddChild<UnitCache>();
                unitCache.key = key;
                self.UnitCacheDictionary.Add(key, unitCache);
            }
        }

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string key)
        {
            UnitCache unitCache;
            if (!self.UnitCacheDictionary.ContainsKey(key))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.key = key;
                self.UnitCacheDictionary.Add(key, unitCache);
            }
            else
            {
                unitCache = self.UnitCacheDictionary[key];
            }

            return await unitCache.Get(unitId);
        }

        public static async ETTask<T> Get<T>(this UnitCacheComponent self, long unitId) where T : Entity
        {
            string key = typeof(T).Name;

            UnitCache unitCache;
            if (!self.UnitCacheDictionary.ContainsKey(key))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.key = key;
                self.UnitCacheDictionary.Add(key, unitCache);
            }
            else
            {
                unitCache = self.UnitCacheDictionary[key];
            }

            return await unitCache.Get(unitId) as T;
        }

        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long id, ListComponent<Entity> entityList)
        {
            using (ListComponent<Entity> list = ListComponent<Entity>.Create())
            {
                foreach (Entity entity in entityList)
                {
                    string key = entity.GetType().FullName;

                    UnitCache unitCache;
                    if (!self.UnitCacheDictionary.ContainsKey(key))
                    {
                        unitCache = self.AddChild<UnitCache>();
                        unitCache.key = key;
                        self.UnitCacheDictionary.Add(key, unitCache);
                    }
                    else
                    {
                        unitCache = self.UnitCacheDictionary[key];
                    }

                    unitCache.AddOrUpdate(entity);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(id, list);
                }
            }
        }

        public static void Delete(this UnitCacheComponent self, long unitId)
        {
            foreach (UnitCache cache in self.UnitCacheDictionary.Values)
            {
                cache.Delete(unitId);
            }
        }
    }
}