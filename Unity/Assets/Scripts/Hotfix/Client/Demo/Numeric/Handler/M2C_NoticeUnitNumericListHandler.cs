namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_NoticeUnitNumericListHandler : MessageHandler<Scene, M2C_NoticeUnitNumericList>
    {
        protected override async ETTask Run(Scene root, M2C_NoticeUnitNumericList message)
        {
            Unit unit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            for (int i = 0; i < message.NumericTypeList.Count; i++)
            {
                int numericType = message.NumericTypeList[i];
                long newValue = message.NewValueList[i];
                numericComponent.Set(numericType, newValue);
            }

            await ETTask.CompletedTask;
        }
    }
}