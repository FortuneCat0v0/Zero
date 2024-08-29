namespace ET.Server
{
    public static class ItemHelper
    {
        public static int Recharge(Unit unit, int num)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            if (!ConfigData.RechargeGive.ContainsKey(num))
            {
                return ErrorCode.ERR_RechargeError;
            }

            numericComponent.Adjust(NumericType.RechargeAmount, num);
            // 1:10
            numericComponent.Adjust(NumericType.Gold, num * 10 + ConfigData.RechargeGive[num]);

            return ErrorCode.ERR_Success;
        }
    }
}