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
            if (self.ClientSkill == null)
            {
                return;
            }

            long cd = self.ClientSkill.GetCurrentCD();
            self.CDText.text = cd <= 0 ? string.Empty : $"{cd / 1000f:0.#}";

            self.CDImg.fillAmount = cd <= 0 ? 0 : cd * 1f / self.ClientSkill.CD;
        }

        public static void SetSkill(this UISkillGrid self, ESkillSlotType skillSlotType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.SkillSlotType = skillSlotType;
            ClientSkillComponent clientSkillComponent = unit.GetComponent<ClientSkillComponent>();
            self.ClientSkill = clientSkillComponent.GetSkillBySlot(skillSlotType);
            self.RefeshIcon().Coroutine();
        }

        private static async ETTask RefeshIcon(this UISkillGrid self)
        {
            await ETTask.CompletedTask;
        }

        private static void OnPointerDown(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            self.SkillIndicatorComponent.ShowIndicator(self.ClientSkill.SkillConfig);
        }

        private static void OnDrag(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            self.SkillIndicatorComponent.UpdateIndicator(pdata.delta);
        }

        private static void OnPointerUp(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.ClientSkill == null)
            {
                return;
            }

            // 发送消息 使用技能
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            SkillIndicatorComponent skillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();
            ClientSkillComponent clientSkillComponent = unit.GetComponent<ClientSkillComponent>();

            long targetUnitId = 0;
            clientSkillComponent.TrySpellSkill(self.SkillSlotType, targetUnitId, skillIndicatorComponent.GetAngle(), skillIndicatorComponent.GetDistance());

            self.SkillIndicatorComponent.HideIndicator();
        }
    }
}