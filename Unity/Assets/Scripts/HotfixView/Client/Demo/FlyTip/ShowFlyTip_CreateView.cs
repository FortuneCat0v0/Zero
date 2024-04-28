namespace ET.Client
{
    [Event(SceneType.Current)]
    public class ShowFlyTip_CreateView : AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            if (args.Type == 0)
            {
                scene.Root().GetComponent<FlyTipComponent>().SpawnFlyTipDi(args.Str);
            }
            else
            {
                scene.Root().GetComponent<FlyTipComponent>().SpawnFlyTip(args.Str);
            }

            await ETTask.CompletedTask;
        }
    }
}