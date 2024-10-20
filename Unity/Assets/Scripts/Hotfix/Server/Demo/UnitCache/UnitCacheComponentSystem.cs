using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Invoke((long)SceneType.UnitCache)]
    public class LRUCacheInvoker_DeleteUnitCache : AInvokeHandler<LRUUnitCacheDelete>
    {
        public override void Handle(LRUUnitCacheDelete args)
        {
            LRUCache lruCache = args.LruCache;
            lruCache.GetParent<UnitCacheComponent>().Delete(args.Key).Coroutine();
        }
    }

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
                    self.UnitCacheKeys.Add(type.FullName);
                }
            }

            foreach (string key in self.UnitCacheKeys)
            {
                UnitCache unitCache = self.AddChild<UnitCache>();
                unitCache.Key = key;
                self.UnitCacheDict.Add(key, unitCache);
            }

            self.AddComponent<LRUCache>();
        }

        [EntitySystem]
        private static void Destroy(this UnitCacheComponent self)
        {
            foreach (UnitCache unitCache in self.UnitCacheDict.Values)
            {
                unitCache?.Dispose();
            }

            self.UnitCacheDict.Clear();
        }

        public static void CallCache(this UnitCacheComponent self, long unitId)
        {
            self.GetComponent<LRUCache>().Call(unitId);
        }

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string key)
        {
            UnitCache unitCache;
            if (!self.UnitCacheDict.TryGetValue(key, out var value))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.Key = key;
                self.UnitCacheDict.Add(key, unitCache);
            }
            else
            {
                unitCache = value;
            }

            return await unitCache.Get(unitId);
        }

        public static async ETTask<T> Get<T>(this UnitCacheComponent self, long unitId) where T : Entity
        {
            string key = typeof(T).Name;

            UnitCache unitCache;
            if (!self.UnitCacheDict.TryGetValue(key, out var value))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.Key = key;
                self.UnitCacheDict.Add(key, unitCache);
            }
            else
            {
                unitCache = value;
            }

            return await unitCache.Get(unitId) as T;
        }

        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long unitId, List<Entity> entityList)
        {
            using (ListComponent<Entity> list = ListComponent<Entity>.Create())
            {
                self.CallCache(unitId);
                foreach (Entity entity in entityList)
                {
                    string key = entity.GetType().FullName;
                    UnitCache unitCache;
                    if (!self.UnitCacheDict.TryGetValue(key, out var value))
                    {
                        unitCache = self.AddChild<UnitCache>();
                        unitCache.Key = key;
                        self.UnitCacheDict.Add(key, unitCache);
                    }
                    else
                    {
                        unitCache = value;
                    }

                    unitCache.AddOrUpdate(entity);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(unitId, list);
                }
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask Delete(this UnitCacheComponent self, long unitId)
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnitCacheGet, unitId))
            {
                foreach (UnitCache unitCache in self.UnitCacheDict.Values)
                {
                    unitCache.Delete(unitId);
                }
            }
        }
    }
}