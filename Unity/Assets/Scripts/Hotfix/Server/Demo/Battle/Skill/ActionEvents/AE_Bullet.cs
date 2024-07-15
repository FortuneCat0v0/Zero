using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 技能发射子弹
    /// 参数：数量，子弹的UnitConfigId
    /// </summary>
    public class AE_Bullet : AActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发子弹事件");
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            for (int i = 0; i < param[0]; i++)
            {
                UnitFactory.CreateBullet(root, param[1], new CreateColliderArgs()
                {
                    BelontToUnit = owner,
                    FollowUnitPos = false,
                    FollowUnitRot = false,
                    Offset = default,
                    TargetPos = owner.Position,
                    Angle = skill.Angle,
                    ColliderConfigId = 1001,
                    ActionEvent = "AE_Bullet",
                    Params = default
                });
            }

            await ETTask.CompletedTask;
        }

        public override void HandleCollisionStart(Unit a, Unit b)
        {
            RoleCastComponent aRole = a.GetComponent<RoleCastComponent>();
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            RoleCastComponent bRole = b.GetComponent<RoleCastComponent>();
            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

            ERoleCast roleCast = aRole.GetRoleCastToTarget(b);
            ERoleTag roleTag = bRole.RoleTag;

            switch (roleCast)
            {
                case ERoleCast.Friendly:
                    break;
                case ERoleCast.Adverse:
                    switch (roleTag)
                    {
                        case ERoleTag.Hero:
                            BattleHelper.HitSettle(aBelongToUnit, bBelongToUnit, EHitFromType.Skill_Bullet);
                            break;
                    }

                    break;
                case ERoleCast.Neutral:
                    break;
            }
        }

        public override void HandleCollisionSustain(Unit a, Unit b)
        {
        }

        public override void HandleCollisionEnd(Unit a, Unit b)
        {
        }
    }
}