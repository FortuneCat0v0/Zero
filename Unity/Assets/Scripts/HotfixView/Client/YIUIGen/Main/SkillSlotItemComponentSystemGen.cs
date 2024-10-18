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
    [EntitySystemOf(typeof(SkillSlotItemComponent))]
    public static partial class SkillSlotItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillSlotItemComponent self)
        {
        }

        [EntitySystem]
        private static void YIUIBind(this SkillSlotItemComponent self)
        {
            self.UIBind();
        }
        
        private static void UIBind(this SkillSlotItemComponent self)
        {
            self.u_UIBase = self.GetParent<YIUIComponent>();

            self.u_ComCDImage = self.UIBase.ComponentTable.FindComponent<UnityEngine.UI.Image>("u_ComCDImage");
            self.u_ComCDTextMeshProUGUI = self.UIBase.ComponentTable.FindComponent<TMPro.TextMeshProUGUI>("u_ComCDTextMeshProUGUI");
            self.u_EventOnPointerDown = self.UIBase.EventTable.FindEvent<UIEventP0>("u_EventOnPointerDown");
            self.u_EventOnPointerDownHandle = self.u_EventOnPointerDown.Add(self.OnEventOnPointerDownAction);
            self.u_EventOnDrag = self.UIBase.EventTable.FindEvent<UIEventP1<object>>("u_EventOnDrag");
            self.u_EventOnDragHandle = self.u_EventOnDrag.Add(self.OnEventOnDragAction);
            self.u_EventOnPointerUp = self.UIBase.EventTable.FindEvent<UIEventP0>("u_EventOnPointerUp");
            self.u_EventOnPointerUpHandle = self.u_EventOnPointerUp.Add(self.OnEventOnPointerUpAction);

        }
    }
}