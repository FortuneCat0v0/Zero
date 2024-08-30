namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class AppStartInitFinish_CreateLoginUI : AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            UIComponent uiComponent = root.GetComponent<UIComponent>();
            uiComponent.Remove(UIType.UIHotUpdate);
            await uiComponent.Create(UIType.UILogin, UILayer.Mid);
        }
    }
}