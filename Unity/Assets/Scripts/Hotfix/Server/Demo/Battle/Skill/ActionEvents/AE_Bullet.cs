using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 技能发射子弹
    /// 参数：数量，伤害
    /// </summary>
    public class AE_Bullet : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发子弹事件");
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            for (int i = 0; i < param[0]; i++)
            {
                UnitFactory.CreateBullet(root, new CreateColliderParams()
                {
                    BelontToUnit = owner,
                    FollowUnitPos = false,
                    FollowUnitRot = false,
                    Offset = default,
                    TargetPos = owner.Position,
                    Angle = skill.Angle,
                    ColliderConfigId = 1001,
                    Skill = skill,
                    CollisionHandler = nameof(CH_Normal),
                    Params = new() { param[1] }
                });
            }

            await ETTask.CompletedTask;
        }
    }
}