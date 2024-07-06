using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILoginComponent : Entity, IAwake
    {
        public GameObject NormalBtn;
        public GameObject TapTapBtn;
        public GameObject NormalLoginPanel;
        public GameObject AccountIF;
        public GameObject PasswordIF;
        public GameObject NormalLoginBtn;
        public GameObject CloseNormalLoginPanelBtn;

        public string TapTapOpenid;
    }
}