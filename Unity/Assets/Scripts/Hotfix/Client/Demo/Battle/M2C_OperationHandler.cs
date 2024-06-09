namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_OperationHandler : MessageHandler<Scene, M2C_Operation>
    {
        protected override async ETTask Run(Scene root, M2C_Operation message)
        {
            if (message.OperateType == 0)
            {
                Log.Error("无效 Operation");
                return;
            }

            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                Log.Error($"不存在 Unit {message.UnitId}");
                return;
            }

            EOperateType operateType = (EOperateType)message.OperateType;

            switch (operateType)
            {
                case EOperateType.Move:
                {
                    float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
                    await unit.GetComponent<MoveComponent>().MoveToAsync(message.Value_List_Vec3_1, speed);
                    break;
                }
                case EOperateType.Stop:
                {
                    MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
                    moveComponent.Stop(message.Value_Int_1 == 0);
                    unit.Position = message.Value_Vec3_1;
                    unit.Rotation = message.Value_Qua_1;
                    unit.GetComponent<ObjectWait>()?.Notify(new Wait_UnitStop() { Error = message.Value_Int_1 });
                    break;
                }
                case EOperateType.Skill:
                {
                    EInputType inputType = (EInputType)message.InputType;
                    unit.GetComponent<SkillComponent>()
                            .SpllSkill(inputType, message.Value_Int_1, message.Value_Vec3_1, message.Value_Vec3_2, message.Value_Long_1);
                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}