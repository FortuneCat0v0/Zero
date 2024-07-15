﻿using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SpellSkillHandler : MessageHandler<Scene, M2C_SpellSkill>
    {
        protected override async ETTask Run(Scene root, M2C_SpellSkill message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                Log.Warning($"释放技能 不存在 Unit {message.UnitId}");
                return;
            }

            unit.Rotation = quaternion.RotateY(message.Angle);
            unit.GetComponent<SkillComponent>().SpllSkill(message.SkillConfigId, message.TargetUnitId, message.Position, message.Angle);

            await ETTask.CompletedTask;
        }
    }
}