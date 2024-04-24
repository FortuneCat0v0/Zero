namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NumericChangeEvent_NoticeToClient : AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            M2C_NoticeUnitNumeric m2CNoticeUnitNumeric = M2C_NoticeUnitNumeric.Create();
            m2CNoticeUnitNumeric.UnitId = args.Unit.Id;
            m2CNoticeUnitNumeric.NumericType = args.NumericType;
            m2CNoticeUnitNumeric.NewValue = args.New;
            if (args.IsBroadcast)
            {
                if (args.Unit.Type() == EUnitType.Player)
                {
                    MapMessageHelper.Broadcast(args.Unit, m2CNoticeUnitNumeric);
                }
                else
                {
                    MapMessageHelper.BroadcastNoSelf(args.Unit, m2CNoticeUnitNumeric);
                }
            }
            else
            {
                if (args.Unit.Type() == EUnitType.Player)
                {
                    MapMessageHelper.SendToClient(args.Unit, m2CNoticeUnitNumeric);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}