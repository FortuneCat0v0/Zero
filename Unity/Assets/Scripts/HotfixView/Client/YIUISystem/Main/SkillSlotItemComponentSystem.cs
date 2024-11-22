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
            string path = AssetPathHelper.GetEffectPath("UIEffect/Item_FX_48");
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, self.u_ComUIParticleRectTransform);
            self.u_ComUIParticleRectTransform.GetComponent<Coffee.UIExtensions.UIParticle>().scale = 50f;
            self.u_ComUIParticleRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this SkillSlotItemComponent self)
        {
        }

        [EntitySystem]
        private static void Update(this SkillSlotItemComponent self)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            self.u_ComUIParticleRectTransform.gameObject.SetActive(self.ClientSkill.SkillState == ESkillState.Running);

            long cd = self.ClientSkill.GetCurrentCD();
            self.u_ComCDTextMeshProUGUI.text = cd <= 0 ? string.Empty : $"{cd / 1000f:0.#}";
            self.u_ComCDImage.fillAmount = cd <= 0 ? 0 : cd * 1f / self.ClientSkill.CD;
        }

        public static void SetSkill(this SkillSlotItemComponent self, ESkillSlotType skillSlotType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.SkillSlotType = skillSlotType;
            ClientSkillComponent clientSkillComponent = unit.GetComponent<ClientSkillComponent>();
            self.ClientSkill = clientSkillComponent.GetSkillBySlot(skillSlotType);
            // 加载图标等。。。
        }

        #region YIUIEvent开始

        private static void OnEventOnPointerUpAction(this SkillSlotItemComponent self)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            // 发送消息 使用技能
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            ClientSkillComponent clientSkillComponent = unit.GetComponent<ClientSkillComponent>();

            long targetUnitId = 0;
            clientSkillComponent.TrySpellSkill(self.SkillSlotType, targetUnitId, self.SkillIndicatorComponent.GetAngle(),
                self.SkillIndicatorComponent.GetDistance());

            self.SkillIndicatorComponent.HideIndicator();
        }

        private static void OnEventOnDragAction(this SkillSlotItemComponent self, object p1)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            PointerEventData pdata = p1 as PointerEventData;
            self.SkillIndicatorComponent.UpdateIndicator(pdata.delta);
        }

        private static void OnEventOnPointerDownAction(this SkillSlotItemComponent self)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            self.SkillIndicatorComponent.ShowIndicator(self.ClientSkill.SkillConfig);
        }

        #endregion YIUIEvent结束
    }
}