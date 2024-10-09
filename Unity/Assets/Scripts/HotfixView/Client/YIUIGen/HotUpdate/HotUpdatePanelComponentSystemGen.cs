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
    [EntitySystemOf(typeof(HotUpdatePanelComponent))]
    public static partial class HotUpdatePanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this HotUpdatePanelComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this HotUpdatePanelComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this HotUpdatePanelComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.BanTween|EWindowOption.BanAwaitOpenTween|EWindowOption.BanAwaitCloseTween|EWindowOption.SkipOtherOpenTween|EWindowOption.SkipOtherCloseTween;
            self.UIPanel.Layer = EPanelLayer.Panel;
            self.UIPanel.PanelOption = EPanelOption.TimeCache;
            self.UIPanel.StackOption = EPanelStackOption.None;
            self.UIPanel.Priority = 0;
            self.UIPanel.CachePanelTime = 10;

            self.u_ComPackageVersionTxt = self.UIBase.ComponentTable.FindComponent<TMPro.TextMeshProUGUI>("u_ComPackageVersionTxt");
            self.u_ComProgressTxt = self.UIBase.ComponentTable.FindComponent<TMPro.TextMeshProUGUI>("u_ComProgressTxt");
            self.u_ComProgressBarImg = self.UIBase.ComponentTable.FindComponent<UnityEngine.UI.Image>("u_ComProgressBarImg");

        }
    }
}