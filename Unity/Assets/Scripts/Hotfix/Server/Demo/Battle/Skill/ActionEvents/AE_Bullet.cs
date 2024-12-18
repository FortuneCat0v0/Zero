﻿using System.Collections.Generic;

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
            // Log.Info("触发子弹事件");
            // SkillS skillS = entity as SkillS;
            // Scene root = skillS.Root();
            // Unit owner = skillS.OwnerUnit;
            //
            // TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            // for (int i = 0; i < param[0]; i++)
            // {
            //     UnitFactory.CreateBullet(root, new CreateColliderParams()
            //     {
            //         BelongToUnit = owner,
            //         FollowUnitPos = false,
            //         FollowUnitRot = false,
            //         Offset = default,
            //         TargetPos = owner.Position,
            //         Angle = skillS.Angle + i * (-1 ^ i) * 10,
            //         ColliderConfigId = 1001,
            //         SkillS = skillS,
            //         CollisionHandler = nameof(CH_SimpleArea),
            //         Params = new() { param[1] }
            //     });
            //
            //     if (cancellationToken.IsCancel())
            //     {
            //         return;
            //     }
            //
            //     await timerComponent.WaitAsync(500, cancellationToken);
            // }

            await ETTask.CompletedTask;
        }
    }
}