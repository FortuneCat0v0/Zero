namespace ET.Server
{
    public static class SlimeNoticeHelper
    {
        public static void SyncSlimeInfo(Unit unit, Slime slime, SlimeOpType slimeOpType)
        {
            M2C_SlimeUpdateOp m2CSlimeUpdateOp = M2C_SlimeUpdateOp.Create();
            m2CSlimeUpdateOp.SlimeInfo = slime.ToMessage();
            m2CSlimeUpdateOp.SlimeOpType = (int)slimeOpType;
            MapMessageHelper.SendToClient(unit, m2CSlimeUpdateOp);
        }
    }
}