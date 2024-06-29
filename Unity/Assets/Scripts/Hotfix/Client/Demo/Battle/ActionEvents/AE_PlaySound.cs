using System.Collections.Generic;

namespace ET.Client
{
    public class AE_PlaySound : AActionEvent
    {
        public override async ETTask Execute(Skill skill, List<int> param, ETCancellationToken cancellationToken)
        {
            Unit owner = skill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlaySound()
            {
                AudioConfigId = param[0]
            });

            await ETTask.CompletedTask;
        }
    }
}