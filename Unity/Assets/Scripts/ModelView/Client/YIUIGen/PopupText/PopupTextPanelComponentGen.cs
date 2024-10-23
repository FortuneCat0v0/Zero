using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Panel, EPanelLayer.Popup)]
    public partial class PopupTextPanelComponent: Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "PopupText";
        public const string ResName = "PopupTextPanel";

        public EntityRef<YIUIComponent> u_UIBase;
        public YIUIComponent UIBase => u_UIBase;
        public EntityRef<YIUIWindowComponent> u_UIWindow;
        public YIUIWindowComponent UIWindow => u_UIWindow;
        public EntityRef<YIUIPanelComponent> u_UIPanel;
        public YIUIPanelComponent UIPanel => u_UIPanel;
        public UnityEngine.RectTransform u_ComLayer_0RectTransform;
        public UnityEngine.RectTransform u_ComLayer_1RectTransform;
        public UnityEngine.RectTransform u_ComLayer_2RectTransform;
        public UnityEngine.RectTransform u_ComText_0RectTransform;
        public UnityEngine.RectTransform u_ComText_1RectTransform;
        public UnityEngine.RectTransform u_ComText_2RectTransform;

    }
}