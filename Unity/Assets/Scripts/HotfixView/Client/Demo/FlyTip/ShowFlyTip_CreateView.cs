namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ShowFlyTip_CreateView : AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            FlyTipComponent.Instance.ShowFlyTip(args.Str);

            await ETTask.CompletedTask;
        }
    }
}