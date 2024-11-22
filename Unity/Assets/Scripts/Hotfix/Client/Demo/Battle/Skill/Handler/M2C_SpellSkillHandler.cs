using Unity.Mathematics;

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

            unit.Rotation = quaternion.Euler(0, math.radians(message.Angle), 0);
            unit.GetComponent<ClientSkillComponent>().SpellSkill(message.SkillConfigId, message.TargetUnitId, message.Angle, message.Position);

            await ETTask.CompletedTask;
        }
    }
}