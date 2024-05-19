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

            long cd = self.Skill.CurrentCD;
            self.CDText.text = cd <= 0 ? string.Empty : (cd / 1000).ToString();

            self.CDImg.fillAmount = cd <= 0 ? 0 : cd * 1f / self.Skill.CD;
        }

        public static void SetSkill(this UISkillGrid self, ESkillAbstractType eSkillAbstractType, int skillIndex)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            Skill skill = skillComponent.GetSkill(eSkillAbstractType, skillIndex);

            if (skill == null)
            {
                Log.Warning($"角色未配置技能 {eSkillAbstractType.ToString()} {skillIndex}");
            }

            self.Skill = skill;

            self.SetSkillIcon().Coroutine();
        }

        private static async ETTask SetSkillIcon(this UISkillGrid self)
        {
            await ETTask.CompletedTask;
        }

        private static void OnPointerDown(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.Skill == null)
            {
                return;
            }

            if (self.Skill.IsInCd())
            {
                return;
            }

            // 先锁定一个敌人

            self.SkillIndicatorComponent.ShowIndicator(0, self.Skill.SkillConfig);
        }

        private static void OnDrag(this UISkillGrid self, PointerEventData pdata)
        {
            if (self.Skill == null)
            {
                return;
            }

            if (self.Skill.IsInCd())
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

            if (self.Skill.IsInCd())
            {
                return;
            }

            self.SkillIndicatorComponent.HideIndicator();
            // 发送消息 使用技能
        }
    }
}