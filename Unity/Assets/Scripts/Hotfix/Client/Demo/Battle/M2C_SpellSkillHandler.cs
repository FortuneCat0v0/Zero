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

            unit.GetComponent<SkillComponent>().SpllSkill(message.SkillConfigId, message.TargetUnitId, message.Position, message.Direction);

            await ETTask.CompletedTask;
        }
    }
}