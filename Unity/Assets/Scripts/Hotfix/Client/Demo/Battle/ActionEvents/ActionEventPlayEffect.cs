using System.Collections.Generic;

namespace ET.Client
{
    public class ActionEventPlayEffect : AActionEvent
    {
        public override async ETTask Execute(Skill skill, List<int> param, ETCancellationToken cancellationToken)
        {
            Unit owner = skill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
            {
                Unit = owner,
                EffectId = IdGenerater.Instance.GenerateId(),
                EffectData = new EffectData()
                {
                    EffectConfigId = param[0],
                    TargetUnitId = skill.TargetUnitId,
                    Position = skill.Position,
                    Direction = skill.Direction
                }
            });
            await ETTask.CompletedTask;
        }
    }
}