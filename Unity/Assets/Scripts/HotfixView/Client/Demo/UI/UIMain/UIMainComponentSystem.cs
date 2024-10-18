using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMainComponent))]
    [FriendOf(typeof(UIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.RotateAngleDragPanel = rc.Get<GameObject>("RotateAngleDragPanel");
            self.RotateAngleDragPanel.GetComponent<EventTrigger>().AddEventTrigger(self.BeginDrag, EventTriggerType.BeginDrag);
            self.RotateAngleDragPanel.GetComponent<EventTrigger>().AddEventTrigger(self.Drag, EventTriggerType.Drag);
            self.RotateAngleDragPanel.GetComponent<EventTrigger>().AddEventTrigger(self.EndDrag, EventTriggerType.EndDrag);

            self.Btn_GM = rc.Get<GameObject>("Btn_GM");
            self.Btn_GM.GetComponent<Button>().AddListener(() =>
            {
                self.Scene().GetComponent<UIComponent>().Create(UIType.UIGM, UILayer.Mid).Coroutine();
            });

            self.SettingsBtn = rc.Get<GameObject>("SettingsBtn");
            self.SettingsBtn.GetComponent<Button>().AddListenerAsync(self.OnSettingsBtn);

            self.LBShrinkBtn = rc.Get<GameObject>("LBShrinkBtn");
            self.LBBtns = rc.Get<GameObject>("LBBtns");
            self.BagBtn = rc.Get<GameObject>("BagBtn");
            self.PetBtn = rc.Get<GameObject>("PetBtn");
            self.SkillBtn = rc.Get<GameObject>("SkillBtn");
            self.TaskBtn = rc.Get<GameObject>("TaskBtn");
            self.SocialBtn = rc.Get<GameObject>("SocialBtn");
            self.AchievementBtn = rc.Get<GameObject>("AchievementBtn");
            self.LBShrinkBtn.GetComponent<Button>().AddListener(self.OnLBShrinkBtn);
            self.BagBtn.GetComponent<Button>().AddListenerAsync(self.OnBagBtn);
            self.PetBtn.GetComponent<Button>().AddListenerAsync(self.OnPetBtn);
            self.SkillBtn.GetComponent<Button>().AddListenerAsync(self.OnSkillBtn);
            self.TaskBtn.GetComponent<Button>().AddListenerAsync(self.OnTaskBtn);
            self.SocialBtn.GetComponent<Button>().AddListenerAsync(self.OnSocialBtn);
            self.AchievementBtn.GetComponent<Button>().AddListenerAsync(self.OnAchievementBtn);

            self.UIJoystick = rc.Get<GameObject>("UIJoystick");
            self.UIJoystickComponent = self.AddComponent<UIJoystickComponent, GameObject>(self.UIJoystick);

            self.UIMiniMap = rc.Get<GameObject>("UIMiniMap");
            self.UIMiniMapComponent = self.AddComponent<UIMiniMapComponent, GameObject>(self.UIMiniMap);

            self.UISkillGrid_0 = rc.Get<GameObject>("UISkillGrid_0");
            self.AddChild<UISkillGrid, GameObject>(self.UISkillGrid_0).SetSkill(ESkillSlotType.Slot_0);
            self.UISkillGrid_1 = rc.Get<GameObject>("UISkillGrid_1");
            self.AddChild<UISkillGrid, GameObject>(self.UISkillGrid_1).SetSkill(ESkillSlotType.Slot_1);
            self.UISkillGrid_2 = rc.Get<GameObject>("UISkillGrid_2");
            self.AddChild<UISkillGrid, GameObject>(self.UISkillGrid_2).SetSkill(ESkillSlotType.Slot_2);
            self.UISkillGrid_3 = rc.Get<GameObject>("UISkillGrid_3");
            self.AddChild<UISkillGrid, GameObject>(self.UISkillGrid_3).SetSkill(ESkillSlotType.Slot_3);

            self.PingText = rc.Get<GameObject>("PingText");
        }

        [EntitySystem]
        private static void Update(this UIMainComponent self)
        {
            self.PingText.GetComponent<TMP_Text>().text = $"{TimeInfo.Instance.Ping}ms";
        }

        private static async ETTask OnSettingsBtn(this UIMainComponent self)
        {
            // await UIHelper.Create(self.Scene(), UIType.UISettings, UILayer.Mid);
            Log.Error("背包界面暂未开放");
            await ETTask.CompletedTask;
        }

        #region 左下角按钮

        private static void OnLBShrinkBtn(this UIMainComponent self)
        {
            if (self.LBBtns.activeSelf)
            {
                self.LBBtns.SetActive(false);
                self.LBShrinkBtn.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                self.LBBtns.SetActive(true);
                self.LBShrinkBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }

        private static async ETTask OnBagBtn(this UIMainComponent self)
        {
            // await UIHelper.Create(self.Scene(), UIType.UIBag, UILayer.Mid);
            Log.Error("背包界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnPetBtn(this UIMainComponent self)
        {
            Log.Error("宠物界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSkillBtn(this UIMainComponent self)
        {
            Log.Error("技能界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTaskBtn(this UIMainComponent self)
        {
            Log.Error("任务界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSocialBtn(this UIMainComponent self)
        {
            Log.Error("社交界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnAchievementBtn(this UIMainComponent self)
        {
            Log.Error("成就界面暂未开放");
            await ETTask.CompletedTask;
        }

        #endregion

        private static void BeginDrag(this UIMainComponent self, PointerEventData pdata)
        {
            self.PreviousPressPosition = pdata.position;
            self.Root().CurrentScene().GetComponent<CameraComponent>().StartRotate();
        }

        private static void Drag(this UIMainComponent self, PointerEventData pdata)
        {
            self.AngleX = (pdata.position.x - self.PreviousPressPosition.x) * self.DRAG_TO_ANGLE;
            self.AngleY = (pdata.position.y - self.PreviousPressPosition.y) * self.DRAG_TO_ANGLE;
            self.Root().CurrentScene().GetComponent<CameraComponent>().Rotate(-self.AngleX, -self.AngleY);
            self.PreviousPressPosition = pdata.position;
        }

        private static void EndDrag(this UIMainComponent self, PointerEventData pdata)
        {
            self.Root().CurrentScene().GetComponent<CameraComponent>().EndRotate();
        }
    }
}