using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit CreatePlayer(Scene scene, long id)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
            unit.AddComponent<MoveComponent>();
            unit.Position = new float3(-10, 0, -10);

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 6f, false); // 速度是6米每秒
            numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米

            unitComponent.Add(unit);
            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            unit.AddComponent<BagComponent>();
            unit.AddComponent<EquipmentComponent>();
            unit.AddComponent<SkillComponent>();
            unit.AddComponent<BuffComponent>();

            return unit;
        }

        public static Unit CreateMonster(Scene scene, long id)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1002);
            unit.AddComponent<MoveComponent>();
            unit.Position = new float3(-10, 0, -10);

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 6f, false); // 速度是6米每秒
            numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米

            unitComponent.Add(unit);
            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            unit.AddComponent<PathfindingComponent, string>(scene.Name);
            unit.AddComponent<XunLuoPathComponent>();
            unit.AddComponent<AIComponent, int>(2);
            return unit;
        }

        public static Unit CreateBullet(Scene scene, long id, Skill ownerSkill, int config, List<int> bulletData)
        {
            Log.Info($"Create bullet");
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit owner = ownerSkill.Unit;
            Unit bullet = unitComponent.AddChildWithId<Unit, int>(id, config);

            NumericComponent numericComponent = bullet.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 10f); // 速度是10米每秒
            numericComponent.Set(NumericType.AOI, 15000); // 视野15米
            numericComponent.Set(NumericType.Attack, 1);
            numericComponent.Set(NumericType.MaxHp, 1);
            numericComponent.Set(NumericType.Hp, 1);

            bullet.Position = owner.Position;
            bullet.Forward = owner.Forward;

            bullet.AddComponent<MoveComponent>();
            int time = 5;
            float3 targetPoint = bullet.Position + bullet.Forward * numericComponent.GetAsFloat(NumericType.Speed) * time;
            List<float3> paths = new List<float3>();
            paths.Add(bullet.Position);
            paths.Add(targetPoint);
            bullet.GetComponent<MoveComponent>().MoveToAsync(paths, numericComponent.GetAsFloat(NumericType.Speed)).Coroutine();

            bullet.AddComponent<AOIEntity, int, float3>(15 * 1000, bullet.Position); // 添加AOI后会自动通知范围内玩家生成子弹

            UnitConfig unitConfig = UnitConfigCategory.Instance.Get(bullet.ConfigId);
            bullet.AddComponent<CollisionComponent>().AddCollider(unitConfig.ColliderType,
                new Vector2(unitConfig.ColliderParams[0], unitConfig.ColliderParams[1]), Vector2.Zero, true, bullet);
            bullet.AddComponent<BulletComponent>().Init(ownerSkill, owner);

            return bullet;
        }
    }
}