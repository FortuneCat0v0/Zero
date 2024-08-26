using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.UIFlyTip)]
    public class UIFlyTipEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            try
            {
                string assetsName = $"Assets/Bundles/UI/UIFlyTip/{UIType.UIFlyTip}.prefab";
                GameObject bundleGameObject =
                        await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
                UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UIFlyTip, gameObject);
                ui.AddComponent<UIFlyTipComponent>();
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