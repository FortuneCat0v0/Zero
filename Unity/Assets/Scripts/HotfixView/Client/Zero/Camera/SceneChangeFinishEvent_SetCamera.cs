namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_SetCamera : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            scene.AddComponent<CameraComponent>();

            await ETTask.CompletedTask;
        }
    }
}