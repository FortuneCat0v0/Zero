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
    [FriendOf(typeof(YIUIPanelComponent))]
    [EntitySystemOf(typeof(PopupTextPanelComponent))]
    public static partial class PopupTextPanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PopupTextPanelComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this PopupTextPanelComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this PopupTextPanelComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween|EWindowOption.BanAwaitOpenTween|EWindowOption.BanAwaitCloseTween|EWindowOption.SkipOtherOpenTween|EWindowOption.SkipOtherCloseTween;
            self.UIPanel.Layer = EPanelLayer.Scene;
            self.UIPanel.PanelOption = EPanelOption.Container|EPanelOption.TimeCache;
            self.UIPanel.StackOption = EPanelStackOption.None;
            self.UIPanel.Priority = 0;
            self.UIPanel.CachePanelTime = 10;

            self.u_ComLayer_0RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComLayer_0RectTransform");
            self.u_ComLayer_1RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComLayer_1RectTransform");
            self.u_ComLayer_2RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComLayer_2RectTransform");
            self.u_ComText_0RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComText_0RectTransform");
            self.u_ComText_1RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComText_1RectTransform");
            self.u_ComText_2RectTransform = self.UIBase.ComponentTable.FindComponent<UnityEngine.RectTransform>("u_ComText_2RectTransform");

        }
    }
}