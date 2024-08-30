namespace ET.Client
{
    [Event(SceneType.LockStep)]
    public class LoginFinish_CreateUILSLobby : AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            await scene.GetComponent<UIComponent>().Create(UIType.UILSLobby, UILayer.Mid);
        }
    }
}