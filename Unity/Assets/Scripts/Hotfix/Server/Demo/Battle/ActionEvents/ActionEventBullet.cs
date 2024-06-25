using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 技能发射子弹
    /// </summary>
    public class ActionEventBullet : AActionEvent
    {
        public override async ETTask Execute(Skill skill, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发子弹事件");
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            for (int i = 0; i < param[0]; i++)
            {
                quaternion rotatedQuaternion = quaternion.LookRotation(skill.Direction, math.up());

                UnitFactory.CreateBullet(root, IdGenerater.Instance.GenerateId(), skill, param[1], rotatedQuaternion);
            }

            await ETTask.CompletedTask;
        }
    }
}