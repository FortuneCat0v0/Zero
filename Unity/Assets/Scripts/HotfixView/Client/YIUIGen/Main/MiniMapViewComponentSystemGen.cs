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
    [EntitySystemOf(typeof(MiniMapViewComponent))]
    public static partial class MiniMapViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MiniMapViewComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this MiniMapViewComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this MiniMapViewComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIView = self.UIBase.GetComponent<YIUIViewComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween|EWindowOption.BanAwaitOpenTween|EWindowOption.BanAwaitCloseTween|EWindowOption.SkipOtherOpenTween|EWindowOption.SkipOtherCloseTween;
            self.UIView.ViewWindowType = EViewWindowType.View;
            self.UIView.StackOption = EViewStackOption.None;

            self.u_ComMapRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComMapRectTransform");
            self.u_ComUIMapMarkerRectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComUIMapMarkerRectTransform");

        }
    }
}