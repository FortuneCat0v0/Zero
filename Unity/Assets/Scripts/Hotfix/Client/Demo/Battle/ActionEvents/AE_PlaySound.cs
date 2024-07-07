using System.Collections.Generic;

namespace ET.Client
{
    public class AE_PlaySound : AActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Unit owner = skill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlaySound()
            {
                AudioConfigId = param[0]
            });

            await ETTask.CompletedTask;
        }
    }
}