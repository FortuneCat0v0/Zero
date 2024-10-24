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

            // foreach (byte[] bytes in request.Entitys)
            // {
            //     Entity entity = MongoHelper.Deserialize<Entity>(bytes);
            //     unit.AddComponent(entity);
            // }

            unit.AddComponent<UnitDBSaveComponent>();
            for (int i = 0; i < request.Entitys.Count; i++)
            {
                string k = request.Types[i];
                Type t = CodeTypes.Instance.GetType(k);
                byte[] v = request.Entitys[i];
                unit.GetComponent<UnitDBSaveComponent>().AddToBytes(t, v);
            }

            unit.AddComponent<MoveComponent>();
            // 服务端添加寻路地图
            // unit.AddComponent<PathfindingComponent, string>(scene.Name);
            unit.AddComponent<PathfindingComponent, string>("TestMap");
            unit.Position = new float3(0, 0, 0);

            unit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            TransferHelper.NoticeClient(scene, unit);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            Log.Warning("注意传送后的碰撞体要重新添加");
            unit.AddComponent<ColliderComponent, CreateColliderParams>(new CreateColliderParams()
            {
                BelontToUnit = unit,
                FollowUnitPos = true,
                FollowUnitRot = true,
                Offset = default,
                TargetPos = default,
                Angle = default,
                ColliderConfigId = 1001,
                Skill = default,
                CollisionHandler = default,
                Params = default
            });

            // 解锁location，可以接收发给Unit的消息
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(LocationType.Unit, unit.Id, request.OldActorId, unit.GetActorId());
        }
    }
}