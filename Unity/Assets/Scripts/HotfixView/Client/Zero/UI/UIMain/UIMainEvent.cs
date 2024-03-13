using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.UIMain)]
    public class UIMainEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            try
            {
                string assetsName = $"Assets/Bundles/UI/UIMain/{UIType.UIMain}.prefab";
                GameObject bundleGameObject =
                        await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
                UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UIMain, gameObject);
                ui.AddComponent<UIMainComponent>();
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}