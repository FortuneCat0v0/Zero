namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RechargeHandler : MessageLocationHandler<Unit, C2M_Recharge, M2C_Recharge>
    {
        protected override async ETTask Run(Unit unit, C2M_Recharge request, M2C_Recharge response)
        {
            response.Error = ItemHelper.Recharge(unit, request.Num);

            await ETTask.CompletedTask;
        }
    }
}