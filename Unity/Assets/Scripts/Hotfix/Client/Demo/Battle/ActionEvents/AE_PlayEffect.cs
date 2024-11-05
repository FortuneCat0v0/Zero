using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 播放特效
    /// 参数：EffectConfigId
    /// </summary>
    public class AE_PlayEffect : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            SkillC skillC = entity as SkillC;
            Unit owner = skillC.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
            {
                Unit = owner,
                EffectId = IdGenerater.Instance.GenerateId(),
                EffectData = new EffectData()
                {
                    EffectConfigId = param[0],
                    Position = skillC.Position,
                    Angle = skillC.Angle
                }
            });

            await ETTask.CompletedTask;
        }
    }
}