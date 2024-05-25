namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SpellSkillHandler : MessageLocationHandler<Unit, C2M_SpellSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_SpellSkill message)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            skillComponent.SpellSkill(message.SkillConfigId, message.Direction, message.Position, message.TargetUnitId);
            await ETTask.CompletedTask;
        }
    }
}