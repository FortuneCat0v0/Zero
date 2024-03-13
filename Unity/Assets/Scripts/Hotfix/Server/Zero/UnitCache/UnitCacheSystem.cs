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
            foreach (Entity entity in self.CacheCompoenntsDictionary.Values)
            {
                entity.Dispose();
            }

            self.CacheCompoenntsDictionary.Clear();
            self.key = null;
        }

        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (self.CacheCompoenntsDictionary.ContainsKey(entity.Id))
            {
                Entity oldEntity = self.CacheCompoenntsDictionary[entity.Id];
                if (entity != oldEntity)
                {
                    oldEntity.Dispose();
                }

                self.CacheCompoenntsDictionary.Remove(entity.Id);
            }

            self.CacheCompoenntsDictionary.Add(entity.Id, entity);
        }

        public static async ETTask<Entity> Get(this UnitCache self, long id)
        {
            Entity entity = null;
            if (!self.CacheCompoenntsDictionary.ContainsKey(id))
            {
                entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<Entity>(id, self.key);
                if (entity != null)
                {
                    self.AddOrUpdate(entity);
                }
            }
            else
            {
                entity = self.CacheCompoenntsDictionary[id];
            }

            return entity;
        }

        public static void Delete(this UnitCache self, long id)
        {
            if (!self.CacheCompoenntsDictionary.ContainsKey(id))
            {
                return;
            }

            Entity entity = self.CacheCompoenntsDictionary[id];
            entity?.Dispose();
            self.CacheCompoenntsDictionary.Remove(id);
        }
    }
}