using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UnitTransformComponent))]
    [EntitySystemOf(typeof(UnitTransformComponent))]
    public static partial class UnitTransformComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UnitTransformComponent self)
        {
            GameObjectComponent gameObjectComponent = self.GetParent<Unit>().GetComponent<GameObjectComponent>();
            ReferenceCollector rc = gameObjectComponent.GameObject.GetComponent<ReferenceCollector>();

            // self.HeadPos = rc.Get<GameObject>("Trans_HeadPos").transform;
            // self.GroundPos = rc.Get<GameObject>("Trans_GroundPos").transform;
            // self.ChannelPos = rc.Get<GameObject>("Trans_FrontPos").transform;
            self.CenterPos = rc.Get<GameObject>("Trans_CenterPos").transform;
            // self.LeftHeadPos = rc.Get<GameObject>("Trans_LeftHandPos").transform;
            // self.RightHeadPos = rc.Get<GameObject>("Trans_RightHandPos").transform;
            //
            // self.WeaponStartPos = rc.Get<GameObject>("Trans_WeaponStartPos").transform;
            // self.WeaponCenterPos = rc.Get<GameObject>("Trans_WeaponCenterPos").transform;
            // self.WeaponEndPos = rc.Get<GameObject>("Trans_WeaponEndPos").transform;
        }

        public static Transform GetTranform(this UnitTransformComponent self, UnitPosType unitPosType)
        {
            switch (unitPosType)
            {
                case UnitPosType.Head:
                    return self.HeadPos;
                case UnitPosType.Ground:
                    return self.GroundPos;
                case UnitPosType.Front:
                    return self.ChannelPos;
                case UnitPosType.Center:
                    return self.CenterPos;
                case UnitPosType.LeftHand:
                    return self.LeftHeadPos;
                case UnitPosType.RightHand:
                    return self.RightHeadPos;
                case UnitPosType.WeaponStart:
                    return self.WeaponStartPos;
                case UnitPosType.WeaponCenter:
                    return self.WeaponCenterPos;
                case UnitPosType.WeaponEnd:
                    return self.WeaponEndPos;
            }

            return null;
        }
    }
}