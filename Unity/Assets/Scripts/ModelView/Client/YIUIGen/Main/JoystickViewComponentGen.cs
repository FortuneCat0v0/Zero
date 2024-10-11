using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.View)]
    public partial class JoystickViewComponent: Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize, IYIUIOpen
    {
        public const string PkgName = "Main";
        public const string ResName = "JoystickView";

        public EntityRef<YIUIComponent> u_UIBase;
        public YIUIComponent UIBase => u_UIBase;
        public EntityRef<YIUIWindowComponent> u_UIWindow;
        public YIUIWindowComponent UIWindow => u_UIWindow;
        public EntityRef<YIUIViewComponent> u_UIView;
        public YIUIViewComponent UIView => u_UIView;
        public UnityEngine.UI.Image u_ComJoystickBottomImage;
        public UnityEngine.UI.Image u_ComJoystickThumbImage;
        public UnityEngine.RectTransform u_ComStartAreaRectTransform;
        public UnityEngine.RectTransform u_ComJoystickBottomRectTransform;
        public UnityEngine.RectTransform u_ComJoystickThumbRectTransform;
        public UnityEngine.RectTransform u_ComJoystickRectTransform;
        public UnityEngine.RectTransform u_ComPositionFocusRectTransform;
        public UIEventP1<object> u_EventOnEndDrag;
        public UIEventHandleP1<object> u_EventOnEndDragHandle;
        public UIEventP1<object> u_EventOnDrag;
        public UIEventHandleP1<object> u_EventOnDragHandle;
        public UIEventP1<object> u_EventOnBeginDrag;
        public UIEventHandleP1<object> u_EventOnBeginDragHandle;

    }
}