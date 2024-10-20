namespace ET.Server
{
    [FriendOf(typeof(UnitCache))]
    [EntitySystemOf(typeof(UnitCache))]
    public static partial class UnitCacheSystem
    {
        [EntitySystem]
        private static void Awake(this UnitCache self)
        {
        }

        [EntitySystem]
        private static void Destroy(this UnitCache self)
        {
            foreach (Entity entity in self.CacheComponentsDict.Values)
            {
                entity.Dispose();
            }

            self.CacheComponentsDict.Clear();
            self.Key = null;
        }

        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (self.CacheComponentsDict.ContainsKey(entity.Id))
            {
                Entity oldEntity = self.CacheComponentsDict[entity.Id];
                if (entity != oldEntity)
                {
                    oldEntity.Dispose();
                }

                self.CacheComponentsDict.Remove(entity.Id);
            }

            self.CacheComponentsDict.Add(entity.Id, entity);
        }

        public static async ETTask<Entity> Get(this UnitCache self, long unitId)
        {
            Entity entity = null;
            if (!self.CacheComponentsDict.TryGetValue(unitId, out var value))
            {
                entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<Entity>(unitId, self.Key);
                if (entity != null)
                {
                    self.AddOrUpdate(entity);
                }
            }
            else
            {
                entity = value;
            }

            return entity;
        }

        public static void Delete(this UnitCache self, long unitId)
        {
            if (!self.CacheComponentsDict.TryGetValue(unitId, out var value))
            {
                return;
            }

            Entity entity = value;
            entity?.Dispose();
            self.CacheComponentsDict.Remove(unitId);
        }
    }
}