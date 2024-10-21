using System.Collections.Generic;

namespace ET.Server
{
    public static partial class TransferHelper
    {
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, sceneName);
        }

        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            Scene root = unit.Root();

            // location加锁
            long unitId = unit.Id;

            unit.GetComponent<UnitDBSaveComponent>().SaveChangeNoWait();

            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            // foreach (Entity entity in unit.Components.Values)
            // {
            //     if (entity is ITransfer)
            //     {
            //         request.Entitys.Add(entity.ToBson());
            //     }
            // }

            foreach (var kv in unit.GetComponent<UnitDBSaveComponent>().Bytes)
            {
                request.Types.Add(kv.Key.FullName);
                request.Entitys.Add(kv.Value);
            }

            unit.Dispose();

            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, unitId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }

        public static void NoticeClient(Scene scene, Unit unit)
        {
            // 通知客户端开始切场景
            M2C_StartSceneChange m2CStartSceneChange = M2C_StartSceneChange.Create();
            m2CStartSceneChange.SceneInstanceId = scene.InstanceId;
            m2CStartSceneChange.SceneName = scene.Name;
            MapMessageHelper.SendToClient(unit, m2CStartSceneChange);

            // 通知客户端创建MyUnit
            M2C_CreateMyUnit m2CCreateUnits = M2C_CreateMyUnit.Create();
            m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
            MapMessageHelper.SendToClient(unit, m2CCreateUnits);

            // 通知客户端同步背包信息
            List<Item> items = unit.GetComponent<BagComponent>().GetAllItems();
            M2C_AllItems m2CAllItems = M2C_AllItems.Create();
            m2CAllItems.ItemContainerType = (int)ItemContainerType.Bag;
            foreach (Item item in items)
            {
                m2CAllItems.ItemInfos.Add(item.ToMessage());
            }

            MapMessageHelper.SendToClient(unit, m2CAllItems);

            // 通知客户端同步装备信息
            Dictionary<int, Item> equipItems = unit.GetComponent<EquipmentComponent>().GetAllItems();
            m2CAllItems = M2C_AllItems.Create();
            m2CAllItems.ItemContainerType = (int)ItemContainerType.Equipment;
            foreach (KeyValuePair<int, Item> keyValuePair in equipItems)
            {
                m2CAllItems.EquipPositions.Add(keyValuePair.Key);
                m2CAllItems.ItemInfos.Add(keyValuePair.Value.ToMessage());
            }

            MapMessageHelper.SendToClient(unit, m2CAllItems);
        }
    }
}