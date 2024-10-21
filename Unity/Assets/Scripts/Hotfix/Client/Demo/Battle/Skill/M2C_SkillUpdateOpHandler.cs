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

            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            switch (message.SkillOpType)
            {
                case (int)ESkillOpType.Add:
                {
                    Skill skill = skillComponent.AddChildWithId<Skill>(message.SkillInfo.Id);
                    skill.FromMessage(message.SkillInfo);
                    skillComponent.AddSkill(skill);

                    break;
                }
                case (int)ESkillOpType.Remove:
                {
                    skillComponent.RemoveSkill(message.SkillInfo.SkillConfigId);
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        skillComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
                case (int)ESkillOpType.Interrupt:
                {
                    Skill skill = skillComponent.GetSkillByConfigId(message.SkillInfo.SkillConfigId);
                    skill.EndSpell();

                    break;
                }
                case (int)ESkillOpType.SetSkillGrid:
                {
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        skillComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}