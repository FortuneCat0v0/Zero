﻿using System.Collections.Generic;

namespace ET.Server
{
    public class AE_AddBuff : AActionEvent
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