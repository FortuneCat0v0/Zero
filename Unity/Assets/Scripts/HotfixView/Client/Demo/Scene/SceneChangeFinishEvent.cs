namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            scene.AddComponent<CameraComponent>();
            await YIUIMgrComponent.Inst.Root.OpenPanelAsync<MainPanelComponent>();
            await YIUIMgrComponent.Inst.Root.OpenPanelAsync<PopupTextPanelComponent>();

            await ETTask.CompletedTask;
        }
    }
}