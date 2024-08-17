namespace ET.Server
{
    public static class UnitCacheHelper
    {
        /// <summary>
        /// 保存或者更新玩家缓存
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            Other2UnitCache_AddOrUpdateUnit message = Other2UnitCache_AddOrUpdateUnit.Create();
            message.UnitId = self.Id;
            message.EntityTypes.Add(typeof(T).FullName);
            message.EntityBytes.Add(self.ToBson());
            await self.Root().GetComponent<MessageSender>().Call(StartSceneConfigCategory.Instance.UnitCaches[self.Zone()].ActorId, message);
            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 从UnitCache缓存服获取玩家缓存，如果没有，则从数据库中获取，挂载在MapScene的UnitComponent上
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        {
            ActorId actorId = StartSceneConfigCategory.Instance.UnitCaches[scene.Zone()].ActorId;
            Other2UnitCache_GetUnit message = new() { UnitId = unitId };
            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await scene.Root().GetComponent<MessageSender>().Call(actorId, message);
            if (queryUnit.Error != ErrorCode.ERR_Success || queryUnit.EntityList.Count <= 0)
            {
                return null;
            }

            int indexOf = queryUnit.ComponentNameList.IndexOf(nameof(Unit));

            if (queryUnit.EntityList[indexOf] == null)
            {
                return null;
            }

            Unit unit = MongoHelper.Deserialize<Unit>(queryUnit.EntityList[indexOf]);

            scene.GetComponent<UnitComponent>().AddChild(unit);
            foreach (byte[] bytes in queryUnit.EntityList)
            {
                Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                if (entity == null || entity is Unit)
                {
                    continue;
                }

                unit.AddComponent(entity);
            }

            return unit;
        }

        /// <summary>
        /// 获取玩家某个组件缓存
        /// </summary>
        /// <param name="unitId"></param>
        /// <typeparam name="T">Unit上组件的类型</typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetUnitComponentCache<T>(Scene scene, long unitId) where T : Entity, IUnitCache
        {
            Other2UnitCache_GetUnit message = Other2UnitCache_GetUnit.Create();
            message.UnitId = unitId;
            message.ComponentNameList.Add(typeof(T).Name);
            ActorId actorId = StartSceneConfigCategory.Instance.UnitCaches[scene.Zone()].ActorId;
            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await scene.Root().GetComponent<MessageSender>().Call(actorId, message);
            if (queryUnit.Error == ErrorCode.ERR_Success && queryUnit.EntityList.Count > 0)
            {
                return MongoHelper.Deserialize<T>(queryUnit.EntityList[0]);
            }

            await ETTask.CompletedTask;
            return null;
        }

        /// <summary>
        /// 删除玩家缓存
        /// </summary>
        /// <param name="unitId"></param>
        public static async ETTask DeleteUnitCache(Scene scene, long unitId)
        {
            Other2UnitCache_DeleteUnit message = Other2UnitCache_DeleteUnit.Create();
            message.UnitId = unitId;
            ActorId actorId = StartSceneConfigCategory.Instance.UnitCaches[scene.Zone()].ActorId;
            await scene.Root().GetComponent<MessageSender>().Call(actorId, message);
            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 保存Unit及Unit身上组件到缓存服及数据库中
        /// </summary>
        /// <param name="unit"></param>
        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            Other2UnitCache_AddOrUpdateUnit message = Other2UnitCache_AddOrUpdateUnit.Create();
            message.UnitId = unit.Id;
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(unit.ToBson());

            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is IUnitCache)
                {
                    message.EntityTypes.Add(entity.GetType().FullName);
                    message.EntityBytes.Add((entity).ToBson());
                }
            }

            unit.Root().GetComponent<MessageSender>().Call(StartSceneConfigCategory.Instance.UnitCaches[unit.Zone()].ActorId, message).Coroutine();
        }
    }
}