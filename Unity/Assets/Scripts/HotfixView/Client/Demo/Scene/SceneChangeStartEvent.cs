using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeStartEvent : AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, SceneChangeStart args)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = scene.AddComponent<ResourcesLoaderComponent>();
            scene.AddComponent<UIComponent>();
            scene.AddComponent<AudioComponent>();
            scene.AddComponent<OperaComponent>();
            scene.AddComponent<HitResultTipComponent>();

            // 加载场景资源
            await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/TestMap.unity", LoadSceneMode.Single);

            scene.GetComponent<AudioComponent>().PlayMusic("MainCity.ogg");

            await UIHelper.Create(scene, UIType.UIMain, UILayer.Mid);
        }
    }
}