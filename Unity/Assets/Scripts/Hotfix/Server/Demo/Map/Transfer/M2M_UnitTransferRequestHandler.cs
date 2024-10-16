﻿using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_UnitTransferRequestHandler : MessageHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = MongoHelper.Deserialize<Unit>(request.Unit);

            unitComponent.AddChild(unit);
            unitComponent.Add(unit);

            foreach (byte[] bytes in request.Entitys)
            {
                Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                unit.AddComponent(entity);
            }

            unit.AddComponent<MoveComponent>();
            // unit.AddComponent<PathfindingComponent, string>(scene.Name);
            // 服务端添加寻路地图
            unit.AddComponent<PathfindingComponent, string>("TestMap");
            unit.Position = new float3(0, 0, 0);

            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            // 通知客户端开始切场景
            M2C_StartSceneChange m2CStartSceneChange = M2C_StartSceneChange.Create();
            m2CStartSceneChange.SceneInstanceId = scene.InstanceId;
            m2CStartSceneChange.SceneName = scene.Name;
            MapMessageHelper.SendToClient(unit, m2CStartSceneChange);

            // 通知客户端创建My Unit
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

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            Log.Warning("注意传送后的碰撞体要重新添加");
            // unit.AddComponent<ColliderComponent>().AddCollider(unitConfig.ColliderType,
            //     new Vector2(unitConfig.ColliderParams[0], 0), Vector2.Zero, true, unit);

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}