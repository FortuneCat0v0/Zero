using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMainComponent))]
    [FriendOf(typeof(UIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.UIJoystickComponent = self.AddComponent<UIJoystickComponent, GameObject>(rc.Get<GameObject>("UIJoystick"));
        }
    }
}