using UnityEngine;

namespace ET.Client
{
    public class UIEquipItem : Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject BackImg;
        public GameObject QualityImg;
        public GameObject IconImg;
        public GameObject LockImg;
        public GameObject ClickBtn;

        public EquipPosition EquipPosition;
    }
}

