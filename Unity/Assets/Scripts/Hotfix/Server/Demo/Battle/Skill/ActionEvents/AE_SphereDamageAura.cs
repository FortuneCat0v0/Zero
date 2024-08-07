using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 在一个范围内，持续造成伤害
    /// </summary>
    public class AE_SphereDamageAura : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            UnitFactory.CreateSpecialColliderUnit(root, new CreateColliderArgs()
            {
            });

            await ETTask.CompletedTask;
        }
    }
}