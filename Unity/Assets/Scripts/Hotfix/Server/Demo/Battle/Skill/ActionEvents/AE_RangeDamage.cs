using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Mathematics;

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

            Unit colliderUnit = UnitFactory.CreateColliderUnit(root, new CreateColliderParams()
            {
                BelontToUnit = owner,
                FollowUnitPos = true,
                FollowUnitRot = true,
                Offset = default,
                TargetPos = default,
                Angle = default,
                ColliderConfigId = param[0],
                Skill = skill,
                CollisionHandler = nameof(CH_Normal),
                Params = new() { param[1] }
            });

            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            for (int i = 0; i < 100; ++i) //！！！为了防止死循环，禁止while(true)！！！
            {
                if (cancellationToken.IsCancel())
                {
                    // 打断技能
                    await timerComponent.WaitAsync(500, cancellationToken);
                    colliderUnit?.Dispose(); // ？？这里考虑是否要给碰撞体传入一个最大存在时间，到了时间就自动销毁
                    return;
                }
            }
        }
    }
}