namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class StartHotUpDate_CreatHotUpdateUI : AEvent<Scene, StartHotUpDate>
    {
        protected override async ETTask Run(Scene root, StartHotUpDate args)
        {
            UI ui = await UIHelper.Create(root, UIType.UIHotUpdate, UILayer.Mid);
            ui.GetComponent<UIHotUpdateComponent>().ShowPackageVersion(args.PackageVersion);
        }
    }
}