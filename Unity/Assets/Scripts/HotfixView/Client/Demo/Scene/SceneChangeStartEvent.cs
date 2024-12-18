using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeStartEvent : AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, SceneChangeStart args)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = scene.AddComponent<ResourcesLoaderComponent>();
            scene.AddComponent<AudioComponent>();
            scene.AddComponent<OperaComponent>();

            await YIUIMgrComponent.Inst.Root.OpenPanelAsync<LoadingPanelComponent>();
            scene.Root().GetComponent<GlobalComponent>().Mask.SetActive(false);

            // 加载场景资源
            MapConfig mapConfig = MapConfigCategory.Instance.Get(scene.GetComponent<MapComponent>().MapConfigId);
            await resourcesLoaderComponent.LoadSceneAsync(AssetPathHelper.GetScenePath(mapConfig.AssetPath), LoadSceneMode.Single);

            YIUIMgrComponent.Inst.GetPanel<LoadingPanelComponent>().SetComplete();

            scene.GetComponent<AudioComponent>().PlayMusic("MainCity.ogg");
        }
    }
}