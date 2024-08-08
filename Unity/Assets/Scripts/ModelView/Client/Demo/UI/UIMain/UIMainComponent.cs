using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMainComponent : Entity, IAwake, IUpdate
    {
        public GameObject RotateAngleDragPanel;
        public float DRAG_TO_ANGLE = 0.5f;
        public Vector2 PreviousPressPosition;
        public float AngleX;
        public float AngleY;

        public GameObject SettingsBtn;

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

        public GameObject UIMiniMap;
        public UIMiniMapComponent UIMiniMapComponent { get; set; }

        public GameObject UISkillGrid_0;
        public GameObject UISkillGrid_1;
        public GameObject UISkillGrid_2;

        public GameObject GMInput;
        public GameObject GMSendBtn;

        public GameObject PingText;
    }
}