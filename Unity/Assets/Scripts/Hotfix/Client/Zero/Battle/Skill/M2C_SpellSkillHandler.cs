namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SpellSkillHandler : MessageHandler<Scene, M2C_SpellSkill>
    {
        protected override async ETTask Run(Scene root, M2C_SpellSkill message)
        {
            Scene currentScene = root.CurrentScene();
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.Get(message.UnitId);

            if (unit == null)
            {
                return;
            }

            unit.GetComponent<SkillComponent>().SpllSkill(message.SkillConfigId, message.Direction, message.Position, message.TargetUnitId);

            await ETTask.CompletedTask;
        }
    }
}