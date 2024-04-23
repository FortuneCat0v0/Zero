using TMPro;
using UnityEngine;
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
        }

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
            await UIHelper.Create(self.Scene(), UIType.UIBag, UILayer.Mid);
        }

        private static async ETTask OnPetBtn(this UIMainComponent self)
        {
            Log.Info("宠物界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSkillBtn(this UIMainComponent self)
        {
            Log.Info("技能界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTaskBtn(this UIMainComponent self)
        {
            Log.Info("任务界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSocialBtn(this UIMainComponent self)
        {
            Log.Info("技能界面暂未开放");
            await ETTask.CompletedTask;
        }

        private static async ETTask OnAchievementBtn(this UIMainComponent self)
        {
            Log.Info("成就界面暂未开放");
            await ETTask.CompletedTask;
        }
    }
}