namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShowErrorTip_CreateView : AEvent<Scene, ShowErrorTip>
    {
        protected override async ETTask Run(Scene scene, ShowErrorTip args)
        {
            string str = ErrorCode.GetTip(args.Error);
            if (!string.IsNullOrEmpty(str))
            {
                TipsHelper.OpenSync<TextTipsViewComponent>(str);
            }

            await ETTask.CompletedTask;
        }
    }
}