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

            // 加载场景资源
            await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/TestMap.unity", LoadSceneMode.Single);

            scene.GetComponent<AudioComponent>().PlayMusic("MainCity.ogg");
        }
    }
}