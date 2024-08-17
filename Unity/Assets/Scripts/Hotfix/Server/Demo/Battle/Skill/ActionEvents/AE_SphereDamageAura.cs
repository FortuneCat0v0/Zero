using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 在一个范围内，持续造成伤害
    /// 参数：ColliderConfigId，持续时间，间隔时间，伤害
    /// </summary>
    public class AE_SphereDamageAura : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            UnitFactory.CreateColliderUnit(root,
                new CreateColliderParams()
                {
                    BelontToUnit = owner,
                    FollowUnitPos = false,
                    FollowUnitRot = false,
                    Offset = default,
                    TargetPos = skill.Position,
                    Angle = default,
                    ColliderConfigId = param[0],
                    Skill = skill,
                    CollisionHandler = nameof(CH_ContinuousArea),
                    Params = new() { param[2], param[3] }
                }, param[1]);

            await ETTask.CompletedTask;
        }
    }
}