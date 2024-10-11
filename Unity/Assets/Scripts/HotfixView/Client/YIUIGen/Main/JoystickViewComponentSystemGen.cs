using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [FriendOf(typeof(YIUIComponent))]
    [FriendOf(typeof(YIUIWindowComponent))]
    [FriendOf(typeof(YIUIViewComponent))]
    [EntitySystemOf(typeof(JoystickViewComponent))]
    public static partial class JoystickViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JoystickViewComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this JoystickViewComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this JoystickViewComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIView = self.UIBase.GetComponent<YIUIViewComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween|EWindowOption.BanAwaitOpenTween|EWindowOption.BanAwaitCloseTween|EWindowOption.SkipOtherOpenTween|EWindowOption.SkipOtherCloseTween;
            self.UIView.ViewWindowType = EViewWindowType.View;
            self.UIView.StackOption = EViewStackOption.None;

            self.u_ComJoystickBottomImage = self.UIBase.ComponentTable.FindComponent<UnityEngine.UI.Image>("u_ComJoystickBottomImage");
            self.u_ComJoystickThumbImage = self.UIBase.ComponentTable.FindComponent<UnityEngine.UI.Image>("u_ComJoystickThumbImage");
            self.u_ComStartAreaRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComStartAreaRectTransform");
            self.u_ComJoystickBottomRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComJoystickBottomRectTransform");
            self.u_ComJoystickThumbRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComJoystickThumbRectTransform");
            self.u_ComJoystickRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComJoystickRectTransform");
            self.u_ComPositionFocusRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComPositionFocusRectTransform");
            self.u_EventOnEndDrag = self.UIBase.EventTable.FindEvent<UIEventP1<object>>("u_EventOnEndDrag");
            self.u_EventOnEndDragHandle = self.u_EventOnEndDrag.Add(self.OnEventOnEndDragAction);
            self.u_EventOnDrag = self.UIBase.EventTable.FindEvent<UIEventP1<object>>("u_EventOnDrag");
            self.u_EventOnDragHandle = self.u_EventOnDrag.Add(self.OnEventOnDragAction);
            self.u_EventOnBeginDrag = self.UIBase.EventTable.FindEvent<UIEventP1<object>>("u_EventOnBeginDrag");
            self.u_EventOnBeginDragHandle = self.u_EventOnBeginDrag.Add(self.OnEventOnBeginDragAction);

        }
    }
}