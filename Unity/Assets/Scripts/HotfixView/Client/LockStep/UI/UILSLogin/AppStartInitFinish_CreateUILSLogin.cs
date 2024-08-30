namespace ET.Client
{
    [Event(SceneType.LockStep)]
    public class AppStartInitFinish_CreateUILSLogin : AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            await root.GetComponent<UIComponent>().Create(UIType.UILSLogin, UILayer.Mid);
        }
    }
}