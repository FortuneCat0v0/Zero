using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// 当前Panel所有可用view枚举
    /// </summary>
    public enum EMainPanelViewEnum
    {
        JoystickView = 1,
        MiniMapView = 2,
    }
    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Panel, EPanelLayer.Panel)]
    public partial class MainPanelComponent: Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "Main";
        public const string ResName = "MainPanel";

        public EntityRef<YIUIComponent> u_UIBase;
        public YIUIComponent UIBase => u_UIBase;
        public EntityRef<YIUIWindowComponent> u_UIWindow;
        public YIUIWindowComponent UIWindow => u_UIWindow;
        public EntityRef<YIUIPanelComponent> u_UIPanel;
        public YIUIPanelComponent UIPanel => u_UIPanel;
        public TMPro.TextMeshProUGUI u_ComPingTextMeshProUGUI;
        public EntityRef<ET.Client.SkillSlotItemComponent> u_UISkillSlotItem_3;
        public ET.Client.SkillSlotItemComponent UISkillSlotItem_3 => u_UISkillSlotItem_3;
        public EntityRef<ET.Client.SkillSlotItemComponent> u_UISkillSlotItem_2;
        public ET.Client.SkillSlotItemComponent UISkillSlotItem_2 => u_UISkillSlotItem_2;
        public EntityRef<ET.Client.SkillSlotItemComponent> u_UISkillSlotItem_1;
        public ET.Client.SkillSlotItemComponent UISkillSlotItem_1 => u_UISkillSlotItem_1;
        public EntityRef<ET.Client.SkillSlotItemComponent> u_UISkillSlotItem_0;
        public ET.Client.SkillSlotItemComponent UISkillSlotItem_0 => u_UISkillSlotItem_0;

    }
}