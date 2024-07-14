using System.Collections.Generic;

namespace ET.Client
{
    public class AE_PlayEffect : AActionEvent
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
                    TargetUnitId = skill.TargetUnitId,
                    Position = skill.Position,
                    Direction = skill.Direction
                }
            });
            await ETTask.CompletedTask;
        }

        public override void HandleCollisionStart(Unit a, Unit b)
        {
        }

        public override void HandleCollisionSustain(Unit a, Unit b)
        {
        }

        public override void HandleCollisionEnd(Unit a, Unit b)
        {
        }
    }
}