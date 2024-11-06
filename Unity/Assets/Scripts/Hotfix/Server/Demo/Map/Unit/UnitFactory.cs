using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit CreatePlayer(Scene scene, long id)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChildWithId<Unit, EUnitType, int>(id, EUnitType.Player, 1001);
            unit.AddComponent<MoveComponent>();
            unit.Position = new float3(-10, 0, -10);

            unit.AddComponent<NumericNoticeComponent>();
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.SpeedBase, 6f, false);
            numericComponent.Set(NumericType.AOI, 15000, false);
            numericComponent.Set(NumericType.NowHp, 100, false);
            numericComponent.Set(NumericType.MaxHpBase, 100, false);

            unitComponent.Add(unit);

            unit.AddComponent<BagComponent>();
            unit.AddComponent<EquipmentComponent>();
            unit.AddComponent<SkillSComponent>();
            SkillSComponent skillSComponent = unit.GetComponent<SkillSComponent>();
            // 测试
            skillSComponent.AddSkill(10001);
            skillSComponent.AddSkill(10011);
            skillSComponent.AddSkill(10021);
            skillSComponent.AddSkill(10031);
            skillSComponent.SetSkillSlot(10001, ESkillSlotType.Slot_0);
            skillSComponent.SetSkillSlot(10011, ESkillSlotType.Slot_1);
            skillSComponent.SetSkillSlot(10021, ESkillSlotType.Slot_2);
            skillSComponent.SetSkillSlot(10031, ESkillSlotType.Slot_3);
            unit.AddComponent<BuffSComponent>();
            unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>(ERoleCamp.Player, ERoleTag.Hero);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static Unit CreateItem(Scene scene, float3 position, int itemConfigId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChild<Unit, EUnitType, int>(EUnitType.Item, itemConfigId);
            unit.Position = position;

            unit.AddComponent<NumericNoticeComponent>();
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.AOI, 15000, false);

            unitComponent.Add(unit);

            unit.AddComponent<ColliderComponent, CreateColliderParams>(new(belongToUnit: unit,
                colliderConfigId: 1001,
                followUnitPos: true,
                followUnitRot: true,
                collisionHandler: nameof(CH_PickUpItem)));

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static Unit CreateMonster(Scene scene, float3 position)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChild<Unit, EUnitType, int>(EUnitType.Monster, 1001);
            unit.AddComponent<MoveComponent>();
            unit.Position = position;

            unit.AddComponent<NumericNoticeComponent>();
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.SpeedBase, 5f, false); // 速度是6米每秒
            numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米
            numericComponent.Set(NumericType.NowHp, 100, false);
            numericComponent.Set(NumericType.MaxHpBase, 100, false);

            unitComponent.Add(unit);

            unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>(ERoleCamp.Monster, ERoleTag.Hero);
            unit.AddComponent<ColliderComponent, CreateColliderParams>(new(belongToUnit: unit,
                colliderConfigId: 1001,
                followUnitPos: true,
                followUnitRot: true));

            unit.AddComponent<PathfindingComponent, string>("TestMap");
            unit.AddComponent<XunLuoPathComponent>();
            unit.AddComponent<AIComponent, int>(2);

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
        }

        public static Unit CreateBullet(Scene root, CreateColliderParams createColliderParams)
        {
            UnitComponent unitComponent = root.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, EUnitType, int>(EUnitType.Skill, 1001);
            unitComponent.Add(unit);

            unit.AddComponent<NumericNoticeComponent>();
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            numericComponent.Set(NumericType.SpeedBase, 10f, false); // 速度是10米每秒
            numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米

            unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>(createColliderParams.BelongToUnit.GetComponent<RoleCastComponent>().RoleCamp,
                ERoleTag.SkillCollision);

            unit.AddComponent<ColliderComponent, CreateColliderParams>(createColliderParams);

            unit.AddComponent<MoveComponent>();
            int time = 5;
            float3 targetPoint = unit.Position + unit.Forward * numericComponent.GetAsFloat(NumericType.Speed) * time;
            List<float3> paths = new List<float3>();
            paths.Add(unit.Position);
            paths.Add(targetPoint);
            unit.GetComponent<MoveComponent>().MoveToAsync(paths, numericComponent.GetAsFloat(NumericType.Speed)).Coroutine();

            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position); // 添加AOI后会自动通知范围内玩家生成子弹

            unit.AddComponent<BulletComponent>();

            return unit;
        }

        public static Unit CreateColliderUnit(Scene root, CreateColliderParams createColliderParams, long lifeTime = 0,
        ETCancellationToken cancellationToken = null)
        {
            UnitComponent unitComponent = root.GetComponent<UnitComponent>();

            //为碰撞体新建一个Unit
            Unit unit = unitComponent.AddChild<Unit, EUnitType, int>(EUnitType.Skill, 1001);
            unit.Position = createColliderParams.BelongToUnit.Position;

            if (lifeTime > 0)
            {
                unit.AddComponent<TimeoutComponent, long>(lifeTime);
            }

            if (cancellationToken != null)
            {
                unit.AddComponent<CancellationComponent, ETCancellationToken>(cancellationToken);
            }

            unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>(createColliderParams.BelongToUnit.GetComponent<RoleCastComponent>().RoleCamp,
                ERoleTag.SkillCollision);

            unit.AddComponent<ColliderComponent, CreateColliderParams>(createColliderParams);

            return unit;
        }
    }
}