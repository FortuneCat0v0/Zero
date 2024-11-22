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

            ClientSkillComponent clientSkillComponent = unit.GetComponent<ClientSkillComponent>();
            switch (message.SkillOpType)
            {
                case (int)ESkillOpType.Add:
                {
                    ClientSkill clientSkill = clientSkillComponent.AddChildWithId<ClientSkill>(message.SkillInfo.Id);
                    clientSkill.FromMessage(message.SkillInfo);
                    clientSkillComponent.AddSkill(clientSkill);

                    break;
                }
                case (int)ESkillOpType.Remove:
                {
                    clientSkillComponent.RemoveSkill(message.SkillInfo.SkillConfigId);
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        clientSkillComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
                case (int)ESkillOpType.Interrupt:
                {
                    ClientSkill clientSkill = clientSkillComponent.GetSkillByConfigId(message.SkillInfo.SkillConfigId);
                    clientSkill.EndSpell();

                    break;
                }
                case (int)ESkillOpType.SetSkillGrid:
                {
                    foreach (KeyValuePair_Int_Int keyValuePair in message.SkillGridDict)
                    {
                        clientSkillComponent.SkillSlotDict[keyValuePair.Key] = keyValuePair.Value;
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}