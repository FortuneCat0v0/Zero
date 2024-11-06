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
            // Log.Info("触发添加Buff事件");
            // SkillS skillS = entity as SkillS;
            // Scene root = skillS.Root();
            // Unit owner = skillS.OwnerUnit;
            //
            // owner.GetComponent<BuffSComponent>().AddBuff(param[0]);

            await ETTask.CompletedTask;
        }
    }
}