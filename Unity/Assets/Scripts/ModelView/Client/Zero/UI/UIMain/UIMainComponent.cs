using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMainComponent : Entity, IAwake
    {
        public GameObject GoldText;
        public GameObject GMBtn;
        public GameObject MatchBtn;
    }
}

