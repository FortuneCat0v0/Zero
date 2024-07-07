using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SpellSkillHandler : MessageLocationHandler<Unit, C2M_SpellSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_SpellSkill message)
        {
            unit.SpellSkill(message.SkillConfigId, message.TargetUnitId, message.Position, message.Direction);

            await ETTask.CompletedTask;
        }
    }
}