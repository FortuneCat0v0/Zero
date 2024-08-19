using System.Collections.Generic;

namespace ET.Client
{
    public class AE_PlayEffect : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Unit owner = skill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
            {
                Unit = owner,
                EffectId = IdGenerater.Instance.GenerateId(),
                EffectData = new EffectData()
                {
                    EffectConfigId = param[0],
                    Position = skill.Position,
                    Angle = skill.Angle
                }
            });

            await ETTask.CompletedTask;
        }
    }
}