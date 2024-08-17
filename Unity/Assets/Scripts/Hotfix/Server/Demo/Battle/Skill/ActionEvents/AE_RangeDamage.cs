using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 范围伤害技能
    /// 参数：ColliderConfigId，伤害
    /// </summary>
    public class AE_RangeDamage : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            Unit colliderUnit = UnitFactory.CreateColliderUnit(root,
                new CreateColliderParams()
                {
                    BelontToUnit = owner,
                    FollowUnitPos = true,
                    FollowUnitRot = true,
                    Offset = default,
                    TargetPos = default,
                    Angle = default,
                    ColliderConfigId = param[0],
                    Skill = skill,
                    CollisionHandler = nameof(CH_SimpleArea),
                    Params = new() { param[1] }
                }, 500);

            await ETTask.CompletedTask;
        }
    }
}