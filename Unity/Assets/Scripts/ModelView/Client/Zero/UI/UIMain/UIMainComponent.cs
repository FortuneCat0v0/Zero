using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMainComponent : Entity, IAwake
    {
        public GameObject LBShrinkBtn;
        public GameObject LBBtns;
        public GameObject BagBtn;
        public GameObject PetBtn;
        public GameObject SkillBtn;
        public GameObject TaskBtn;
        public GameObject SocialBtn;
        public GameObject AchievementBtn;
        public GameObject UIJoystick;

        public UIJoystickComponent UIJoystickComponent { get; set; }
    }
}