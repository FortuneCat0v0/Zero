using System;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeStartEvent : AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, SceneChangeStart args)
        {
            scene.AddComponent<UIComponent>();
            ResourcesLoaderComponent resourcesLoaderComponent = scene.AddComponent<ResourcesLoaderComponent>();
            AudioComponent audioComponent = scene.AddComponent<AudioComponent>();
            scene.AddComponent<OperaComponent>();

            // 加载场景资源
            await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/TestMap.unity", LoadSceneMode.Single);

            audioComponent.PlayMusic("MainCity.ogg");

            await UIHelper.Create(scene, UIType.UIMain, UILayer.Mid);
        }
    }
}