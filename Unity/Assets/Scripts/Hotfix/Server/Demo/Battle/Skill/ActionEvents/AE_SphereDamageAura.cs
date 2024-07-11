using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 在一个范围内，持续造成伤害
    /// </summary>
    public class AE_SphereDamageAura : AActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            // 也许要加一个配置判断技能结束要不要 cancellationToken

            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            while (true)
            {
                if (cancellationToken.IsCancel())
                {
                    return;
                }

                await timerComponent.WaitAsync(param[0], cancellationToken);
            }
        }
    }
}