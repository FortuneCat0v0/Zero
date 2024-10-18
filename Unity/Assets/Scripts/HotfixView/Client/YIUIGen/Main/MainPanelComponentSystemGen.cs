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
    [EntitySystemOf(typeof(MainPanelComponent))]
    public static partial class MainPanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MainPanelComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this MainPanelComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this MainPanelComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();
            self.u_UIWindow = self.UIBase.GetComponent<YIUIWindowComponent>();
            self.u_UIPanel = self.UIBase.GetComponent<YIUIPanelComponent>();
            self.UIWindow.WindowOption = EWindowOption.None;
            self.UIPanel.Layer = EPanelLayer.Panel;
            self.UIPanel.PanelOption = EPanelOption.ForeverCache|EPanelOption.DisClose;
            self.UIPanel.StackOption = EPanelStackOption.VisibleTween;
            self.UIPanel.Priority = 0;

            self.u_ComPingTextMeshProUGUI = self.UIBase.ComponentTable.FindComponent<TMPro.TextMeshProUGUI>("u_ComPingTextMeshProUGUI");
            self.u_UISkillSlotItem_3 = self.UIBase.CDETable.FindUIOwner<ET.Client.SkillSlotItemComponent>("SkillSlotItem_3");
            self.u_UISkillSlotItem_2 = self.UIBase.CDETable.FindUIOwner<ET.Client.SkillSlotItemComponent>("SkillSlotItem_2");
            self.u_UISkillSlotItem_1 = self.UIBase.CDETable.FindUIOwner<ET.Client.SkillSlotItemComponent>("SkillSlotItem_1");
            self.u_UISkillSlotItem_0 = self.UIBase.CDETable.FindUIOwner<ET.Client.SkillSlotItemComponent>("SkillSlotItem_0");

        }
    }
}