using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(SkillSlotItemComponent))]
    public static partial class SkillSlotItemComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this SkillSlotItemComponent self)
        {
            self.SkillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();
        }

        [EntitySystem]
        private static void Destroy(this SkillSlotItemComponent self)
        {
        }

        [EntitySystem]
        private static void Update(this SkillSlotItemComponent self)
        {
            if (self.Skill == null)
            {
                return;
            }

            long cd = self.Skill.GetCurrentCD();
            self.u_ComCDTextMeshProUGUI.text = cd <= 0 ? string.Empty : $"{cd / 1000f:0.#}";
            self.u_ComCDImage.fillAmount = cd <= 0 ? 0 : cd * 1f / self.Skill.GetCD();
        }

        public static void SetSkill(this SkillSlotItemComponent self, ESkillSlotType skillSlotType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.SkillSlotType = skillSlotType;
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            self.Skill = skillComponent.GetSkillByGrid(skillSlotType);
            // 加载图标等。。。
        }

        #region YIUIEvent开始

        private static void OnEventOnPointerUpAction(this SkillSlotItemComponent self)
        {
            if (self.Skill == null)
            {
                return;
            }

            // 发送消息 使用技能
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();

            long targetUnitId = 0;
            skillComponent.TrySpellSkill(self.SkillSlotType, targetUnitId, self.SkillIndicatorComponent.GetAngle(),
                self.SkillIndicatorComponent.GetDistance());

            self.SkillIndicatorComponent.HideIndicator();
        }

        private static void OnEventOnDragAction(this SkillSlotItemComponent self, object p1)
        {
            if (self.Skill == null)
            {
                return;
            }

            PointerEventData pdata = p1 as PointerEventData;
            self.SkillIndicatorComponent.UpdateIndicator(pdata.delta);
        }

        private static void OnEventOnPointerDownAction(this SkillSlotItemComponent self)
        {
            if (self.Skill == null)
            {
                return;
            }

            self.SkillIndicatorComponent.ShowIndicator(self.Skill.SkillConfig);
        }

        #endregion YIUIEvent结束
    }
}