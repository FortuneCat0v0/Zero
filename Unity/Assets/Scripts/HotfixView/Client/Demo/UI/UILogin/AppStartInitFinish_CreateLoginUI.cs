namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class AppStartInitFinish_CreateLoginUI : AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            UIHelper.Remove(root, UIType.UIHotUpdate);
            await UIHelper.Create(root, UIType.UILogin, UILayer.Mid);
        }
    }
}