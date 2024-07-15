using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UISkillGrid))]
    [EntitySystemOf(typeof(UISkillGrid))]
    public static partial class UISkillGridSystem
    {
        [EntitySystem]
        private static void Awake(this UISkillGrid self, GameObject gameObject)
        {
            self.GameObject = gameObject;

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.IconImg = rc.Get<GameObject>("IconImg");
            self.LevelImgs = rc.Get<GameObject>("LevelImgs");
            self.CDImg = rc.Get<GameObject>("CDImg").GetComponent<Image>();
            self.CDText = rc.Get<GameObject>("CDText").GetComponent<TMP_Text>();
            self.ETrigger = rc.Get<GameObject>("ETrigger");

            self.SkillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();

            self.ETrigger.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerDown, EventTriggerType.PointerDown);
            self.ETrigger.GetComponent<EventTrigger>().AddEventTrigger(self.OnDrag, EventTriggerType.Drag);
            self.ETrigger.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerUp, EventTriggerType.PointerUp);
        }

        [EntitySystem]
        private static void Update(this UISkillGrid self)
        {
            if (self.Skill == null)
            {
                return;
            }

            long cd = self.Skill.GetCurrentCD();
            self.CDText.text = cd <= 0 ? string.Empty : $"{cd / 1000f:0.#}";

            self.CDImg.fillAmount = cd <= 0 ? 0 : cd * 1f / self.Skill.GetCD();
        }

        public static void SetSkill(this UISkillGrid self, ESkillGridType skillGridType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.SkillGridType = skillGridType;
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            self.Skill = skillComponent.GetSkillByGrid(skillGridType);
            self.RefeshIcon().Coroutine();
        }

        private static async ETTask RefeshIcon(this UISkillGrid self)
        {
            await ETTask.CompletedTask;
        }

        private static void OnPointerDown(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.Skill == null)
            {
                return;
            }

            // 先锁定一个敌人
            long targetUnitId = 0;
            self.SkillIndicatorComponent.ShowIndicator(targetUnitId, self.Skill.SkillConfig);
        }

        private static void OnDrag(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.Skill == null)
            {
                return;
            }

            self.SkillIndicatorComponent.UpdateIndicator(pdata.delta);
        }

        private static void OnPointerUp(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.Skill == null)
            {
                return;
            }

            // 发送消息 使用技能
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            SkillIndicatorComponent skillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();

            long targetUnitId = 0;
            skillComponent.TrySpellSkill(self.SkillGridType, skillIndicatorComponent.GetAngle(), skillIndicatorComponent.GetPosition(),
                targetUnitId);

            self.SkillIndicatorComponent.HideIndicator();
        }
    }
}