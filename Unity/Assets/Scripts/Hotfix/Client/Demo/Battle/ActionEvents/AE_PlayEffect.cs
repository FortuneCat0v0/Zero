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
            ClientSkill clientSkill = entity as ClientSkill;
            Unit owner = clientSkill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
            {
                Unit = owner,
                EffectId = IdGenerater.Instance.GenerateId(),
                EffectData = new EffectData()
                {
                    EffectConfigId = param[0],
                    Position = clientSkill.Position,
                    Angle = clientSkill.Angle
                }
            });

            await ETTask.CompletedTask;
        }
    }
}