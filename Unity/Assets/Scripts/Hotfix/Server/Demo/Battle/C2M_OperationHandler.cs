namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_OperationHandler : MessageLocationHandler<Unit, C2M_Operation>
    {
        protected override async ETTask Run(Unit unit, C2M_Operation message)
        {
            if (message.OperateType == 0)
            {
                Log.Error("无效 Operation");
                return;
            }

            EOperateType operateType = (EOperateType)message.OperateType;

            switch (operateType)
            {
                case EOperateType.Move:
                {
                    // 不能用await!
                    unit.FindPathMoveToAsync(message.Value_Vec3_1).Coroutine();
                    break;
                }
                case EOperateType.Stop:
                {
                    unit.Stop(1);
                    break;
                }
                case EOperateType.Skill:
                {
                    EInputType inputType = (EInputType)message.InputType;

                    SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
                    if (skillComponent.SpellSkill(inputType, message.Value_Int_1, message.Value_Vec3_1, message.Value_Vec3_2, message.Value_Long_1))
                    {
                        M2C_Operation m2COperation = M2C_Operation.Create();
                        m2COperation.UnitId = unit.Id;
                        m2COperation.OperateType = (int)EOperateType.Skill;
                        m2COperation.InputType = (int)inputType;
                        m2COperation.Value_Int_1 = message.Value_Int_1;
                        m2COperation.Value_Vec3_1 = message.Value_Vec3_1;
                        m2COperation.Value_Vec3_2 = message.Value_Vec3_2;
                        m2COperation.Value_Long_1 = message.Value_Long_1;

                        MapMessageHelper.Broadcast(unit, m2COperation);
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}