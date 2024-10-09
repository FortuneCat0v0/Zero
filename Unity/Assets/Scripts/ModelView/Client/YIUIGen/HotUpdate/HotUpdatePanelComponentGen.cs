using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Panel, EPanelLayer.Panel)]
    public partial class HotUpdatePanelComponent: Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "HotUpdate";
        public const string ResName = "HotUpdatePanel";

        public EntityRef<YIUIComponent> u_UIBase;
        public YIUIComponent UIBase => u_UIBase;
        public EntityRef<YIUIWindowComponent> u_UIWindow;
        public YIUIWindowComponent UIWindow => u_UIWindow;
        public EntityRef<YIUIPanelComponent> u_UIPanel;
        public YIUIPanelComponent UIPanel => u_UIPanel;
        public TMPro.TextMeshProUGUI u_ComPackageVersionTxt;
        public TMPro.TextMeshProUGUI u_ComProgressTxt;
        public UnityEngine.UI.Image u_ComProgressBarImg;

    }
}