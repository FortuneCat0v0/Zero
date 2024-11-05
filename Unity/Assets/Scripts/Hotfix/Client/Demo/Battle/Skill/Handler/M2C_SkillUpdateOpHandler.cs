namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SkillUpdateOpHandler : MessageHandler<Scene, M2C_SkillUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_SkillUpdateOp message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            SkillCComponent skillCComponent = unit.GetComponent<SkillCComponent>();
            switch (message.SkillOpType)
            {
                case (int)ESkillOpType.Add:
                {
                    SkillC skillC = skillCComponent.AddChildWithId<SkillC>(message.SkillInfo.Id);
                    skillC.FromMessage(message.SkillInfo);
                    skillCComponent.AddSkill(skillC);

                    break;
                }
                case (int)ESkillOpType.Remove:
                {
                    skillCComponent.RemoveSkill(message.SkillInfo.SkillConfigId);
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        skillCComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
                case (int)ESkillOpType.Interrupt:
                {
                    SkillC skillC = skillCComponent.GetSkillByConfigId(message.SkillInfo.SkillConfigId);
                    skillC.EndSpell();

                    break;
                }
                case (int)ESkillOpType.SetSkillGrid:
                {
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        skillCComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}