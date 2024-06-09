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
        public override bool Check(Skill skill)
        {
            return true;
        }

        public override async ETTask Execute(Skill skill, ETCancellationToken cancellationToken)
        {
            Log.Info("触发子弹事件");
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;
            List<int> param = skill.CurrentExecuteSkillConfig.ActionEventParamsServer[skill.CurrentActionEventIndex];

            quaternion ownerRotation = owner.Rotation;
            int direct = 1;
            for (int i = 0; i < param[0]; i++)
            {
                direct = -direct;

                quaternion rotatedQuaternion = math.mul(ownerRotation, quaternion.RotateY(i * direct * 5f));

                UnitFactory.CreateBullet(root, IdGenerater.Instance.GenerateId(), skill, param[1], rotatedQuaternion);
            }

            skill.NextActionEventIndex++;
            await ETTask.CompletedTask;
        }
    }
}