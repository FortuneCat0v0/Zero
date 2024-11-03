namespace ET.Server
{
    [Event(SceneType.All)]
    public class NumericChangeEvent_NoticeToClient : AEvent<Scene, NumericChange>
    {
        protected override async ETTask Run(Scene scene, NumericChange args)
        {
            args.Unit.GetComponent<NumericNoticeComponent>()?.Notice(args.NumericType, args.New);

            await ETTask.CompletedTask;
        }
    }
}