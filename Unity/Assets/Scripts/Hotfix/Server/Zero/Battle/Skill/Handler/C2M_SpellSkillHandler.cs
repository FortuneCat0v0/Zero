namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SpellSkillHandler : MessageLocationHandler<Unit, C2M_SpellSkill, M2C_SpellSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_SpellSkill request, M2C_SpellSkill response)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            Skill skill = skillComponent.AddSkill(1002);
            skill.StartSpell();
            await ETTask.CompletedTask;
        }
    }
}