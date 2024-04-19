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

            SkillComponent skillComponent = unit.AddComponent<SkillComponent>();
            // 添加测试技能
            skillComponent.AddSkill(1001);
            skillComponent.AddSkill(1002);

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
            Log.Info($"create bullet");
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit owner = ownerSkill.Unit;
            Unit bullet = unitComponent.AddChildWithId<Unit, int>(id, config);
            MoveComponent moveComponent = bullet.AddComponent<MoveComponent>();
            bullet.Position = owner.Position;
            bullet.Forward = owner.Forward;
            bullet.AddComponent<AOIEntity, int, float3>(15 * 1000, bullet.Position);
            bullet.AddComponent<CollisionComponent>().AddCollider(EColliderType.Circle, Vector2.One * 0.2f, Vector2.Zero, true, bullet);
            bullet.AddComponent<BulletComponent>().Init(ownerSkill, owner);

            NumericComponent numericComponent = bullet.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.Speed, 10f); // 速度是10米每秒
            numericComponent.Set(NumericType.AOI, 15000); // 视野15米
            numericComponent.Set(NumericType.Attack, 1);
            numericComponent.Set(NumericType.MaxHp, 1);
            numericComponent.Set(NumericType.Hp, 1);

            float3 targetPoint = bullet.Position + bullet.Forward * numericComponent.GetAsFloat(NumericType.Speed) * 0.6f;
            List<float3> paths = new List<float3>();
            paths.Add(bullet.Position);
            paths.Add(targetPoint);
            moveComponent.MoveToAsync(paths, numericComponent.GetAsFloat(NumericType.Speed)).Coroutine();

            return bullet;
        }
    }
}