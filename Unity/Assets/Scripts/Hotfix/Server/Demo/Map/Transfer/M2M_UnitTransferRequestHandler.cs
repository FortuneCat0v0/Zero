using System;
using System.Collections.Generic;
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

            unit.AddComponent<UnitDBSaveComponent>();
            for (int i = 0; i < request.Entitys.Count; i++)
            {
                string k = request.Types[i];
                Type t = CodeTypes.Instance.GetType(k);
                byte[] v = request.Entitys[i];
                unit.GetComponent<UnitDBSaveComponent>().AddToBytes(t, v);
            }

            unit.AddComponent<NumericNoticeComponent>();
            unit.AddComponent<MoveComponent>();

            // 传送后的一些处理
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            MapConfig mapConfig = MapConfigCategory.Instance.Get(mapComponent.MapConfigId);
            switch (mapComponent.MapType)
            {
                case MapType.Map1:
                {
                    unit.AddComponent<PathfindingComponent, string>(mapConfig.NavName);
                    unit.Position = new float3(mapConfig.PlayerSpawnPoint.X, mapConfig.PlayerSpawnPoint.Y, mapConfig.PlayerSpawnPoint.Z);
                    break;
                }
                case MapType.Map2:
                {
                    unit.AddComponent<PathfindingComponent, string>(mapConfig.NavName);
                    unit.Position = new float3(mapConfig.PlayerSpawnPoint.X, mapConfig.PlayerSpawnPoint.Y, mapConfig.PlayerSpawnPoint.Z);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            TransferHelper.NoticeClient(scene, unit);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            Log.Warning("注意传送后的碰撞体要重新添加");
            unit.AddComponent<ColliderComponent, CreateColliderParams>(new(belongToUnit: unit,
                colliderConfigId: 1001,
                followUnitPos: true,
                followUnitRot: true));

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}