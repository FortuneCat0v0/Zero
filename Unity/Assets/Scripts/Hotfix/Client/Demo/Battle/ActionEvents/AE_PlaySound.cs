using System.Collections.Generic;

namespace ET.Client
{
    public class AE_PlaySound : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            ClientSkill clientSkill = entity as ClientSkill;
            Unit owner = clientSkill.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlaySound()
            {
                AudioConfigId = param[0]
            });

            await ETTask.CompletedTask;
        }
    }
}