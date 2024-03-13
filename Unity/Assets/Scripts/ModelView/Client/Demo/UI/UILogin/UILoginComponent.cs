using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UILoginComponent : Entity, IAwake
    {
        public GameObject AccountIF;
        public GameObject PasswordIF;
        public GameObject LoginBtn;
    }
}