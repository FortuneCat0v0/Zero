namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            // 获取数据
            await KnapsackHelper.GetAllItems(scene.Root());
            await PetHelper.GetAllPets(scene.Root());

            scene.AddComponent<CameraComponent>();

            await YIUIMgrComponent.Inst.Root.OpenPanelAsync<MainPanelComponent>();
            await YIUIMgrComponent.Inst.Root.OpenPanelAsync<PopupTextPanelComponent>();

            await ETTask.CompletedTask;
        }
    }
}