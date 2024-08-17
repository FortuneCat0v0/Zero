using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UIEquipItem))]
    [EntitySystemOf(typeof(UIEquipItem))]
    public static partial class UIEquipItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIEquipItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.BackImg = rc.Get<GameObject>("BackImg");
            self.QualityImg = rc.Get<GameObject>("QualityImg");
            self.IconImg = rc.Get<GameObject>("IconImg");
            self.LockImg = rc.Get<GameObject>("LockImg");
            self.ClickBtn = rc.Get<GameObject>("ClickBtn");
        }

        public static void Refresh(this UIEquipItem self, EquipPosition equipPosition)
        {
            self.EquipPosition = equipPosition;
        }
    }
}

