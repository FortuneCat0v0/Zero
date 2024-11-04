using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{

    /// <summary>
    /// 由YIUI工具自动创建 请勿修改
    /// </summary>
    [YIUI(EUICodeType.Common)]
    public partial class SkillSlotItemComponent: Entity, IDestroy, IAwake, IYIUIBind, IYIUIInitialize
    {
        public const string PkgName = "Main";
        public const string ResName = "SkillSlotItem";

        public EntityRef<YIUIComponent> u_UIBase;
        public YIUIComponent UIBase => u_UIBase;
        public UnityEngine.UI.Image u_ComCDImage;
        public TMPro.TextMeshProUGUI u_ComCDTextMeshProUGUI;
        public UnityEngine.RectTransform u_ComUIParticleRectTransform;
        public UIEventP0 u_EventOnPointerDown;
        public UIEventHandleP0 u_EventOnPointerDownHandle;
        public UIEventP1<object> u_EventOnDrag;
        public UIEventHandleP1<object> u_EventOnDragHandle;
        public UIEventP0 u_EventOnPointerUp;
        public UIEventHandleP0 u_EventOnPointerUpHandle;

    }
}