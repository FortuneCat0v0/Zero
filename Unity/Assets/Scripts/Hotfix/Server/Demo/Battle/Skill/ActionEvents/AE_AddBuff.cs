using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 为自身添加Buff
    /// 参数：BuffConfigId
    /// </summary>
    public class AE_AddBuff : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发添加Buff事件");
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            owner.GetComponent<BuffComponent>().AddBuff(param[0]);

            await ETTask.CompletedTask;
        }
    }
}