using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SpellSkillHandler : MessageLocationHandler<Unit, C2M_SpellSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_SpellSkill message)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            // 这里可以做一些数据校验

            float3 direction = new(message.Direction.x, 0, message.Direction.z);

            if (skillComponent.SpellSkill(message.SkillConfigId, message.TargetUnitId, message.Position, direction))
            {
                M2C_SpellSkill m2CSpellSkill = M2C_SpellSkill.Create();
                m2CSpellSkill.UnitId = unit.Id;
                m2CSpellSkill.SkillConfigId = message.SkillConfigId;
                m2CSpellSkill.TargetUnitId = message.TargetUnitId;
                m2CSpellSkill.Position = message.Position;
                m2CSpellSkill.Direction = direction;

                MapMessageHelper.Broadcast(unit, m2CSpellSkill);
            }

            await ETTask.CompletedTask;
        }
    }
}