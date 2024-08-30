namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class LoginFinish_RemoveLoginUI : AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            scene.GetComponent<UIComponent>().Remove(UIType.UILogin);

            await ETTask.CompletedTask;
        }
    }
}