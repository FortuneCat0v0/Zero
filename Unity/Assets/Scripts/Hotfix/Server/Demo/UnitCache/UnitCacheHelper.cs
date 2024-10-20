using System;

namespace ET.Server
{
    public static class UnitCacheHelper
    {
        public static async ETTask<Unit> GetUnitCache(Scene gateScene, Scene mapScene, long unitId)
        {
            ActorId actorId = StartSceneConfigCategory.Instance.GetOneBySceneType(gateScene.Zone(), SceneType.UnitCache).ActorId;
            Other2UnitCache_GetUnit message = Other2UnitCache_GetUnit.Create();
            message.UnitId = unitId;

            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await gateScene.GetComponent<MessageSender>().Call(actorId, message);
            if (queryUnit.Error != ErrorCode.ERR_Success || queryUnit.EntityList.Count <= 0)
            {
                return null;
            }

            Unit unit = null;
            int indexOf = queryUnit.ComponentNameList.IndexOf("ET.Unit");
            if (indexOf >= 0)
            {
                if (queryUnit.EntityList[indexOf] != null)
                {
                    unit = MongoHelper.Deserialize<Entity>(queryUnit.EntityList[indexOf]) as Unit;
                }
            }

            if (unit == null)
            {
                return null;
            }

            mapScene.GetComponent<UnitComponent>().AddChild(unit);

            if (unit.GetComponent<UnitDBSaveComponent>() == null)
            {
                unit.AddComponent<UnitDBSaveComponent>();
            }

            for (int i = 0; i < queryUnit.EntityList.Count; i++)
            {
                if (i == indexOf)
                {
                    continue;
                }

                byte[] entityByte = queryUnit.EntityList[i];
                Type type = CodeTypes.Instance.GetType(queryUnit.ComponentNameList[i]);

                EventSystem.Instance.Invoke((long)SceneType.UnitCache, new AddToBytes() { Unit = unit, Type = type, Bytes = entityByte });
            }

            return unit;
        }

        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            Other2UnitCache_AddOrUpdateUnit message = Other2UnitCache_AddOrUpdateUnit.Create();
            message.UnitId = unit.Id;
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(unit.ToBson());

            foreach (Entity entity in unit.Components.Values)
            {
                Type type = entity.GetType();

                if (!typeof(IUnitCache).IsAssignableFrom(type))
                {
                    continue;
                }

                message.EntityTypes.Add(type.FullName);
                byte[] bytes = entity.ToBson();
                message.EntityBytes.Add(bytes);

                EventSystem.Instance.Invoke((long)SceneType.UnitCache, new AddToBytes() { Unit = unit, Type = type, Bytes = bytes });
            }

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetOneBySceneType(unit.Zone(), SceneType.UnitCache);
            unit.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message).Coroutine();
        }
    }
}