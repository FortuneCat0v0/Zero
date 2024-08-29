namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RechargeHandler : MessageLocationHandler<Unit, C2M_Recharge, M2C_Recharge>
    {
        protected override async ETTask Run(Unit unit, C2M_Recharge request, M2C_Recharge response)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            if (!ConfigData.RechargeGive.ContainsKey(request.Num))
            {
                response.Error = ErrorCode.ERR_RechargeError;
                return;
            }

            numericComponent.Adjust(NumericType.RechargeAmount, request.Num);
            // 1:10
            numericComponent.Adjust(NumericType.Gold, request.Num * 10 + ConfigData.RechargeGive[request.Num]);

            await ETTask.CompletedTask;
        }
    }
}