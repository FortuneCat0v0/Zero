using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UISettingsComponent))]
    [EntitySystemOf(typeof(UISettingsComponent))]
    public static partial class UISettingsComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UISettingsComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.CloseBtn = rc.Get<GameObject>("CloseBtn");
            self.CloseBtn.GetComponent<Button>().AddListener(self.OnCloseBtn);
        }

        private static void OnCloseBtn(this UISettingsComponent self)
        {
            self.Scene().GetComponent<UIComponent>().Remove(UIType.UISettings);
        }
    }
}