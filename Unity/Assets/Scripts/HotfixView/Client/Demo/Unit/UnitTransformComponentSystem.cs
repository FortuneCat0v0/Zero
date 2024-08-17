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

        public static Transform GetTranform(this UnitTransformComponent self, PosType posType)
        {
            switch (posType)
            {
                case PosType.HEAD:
                    return self.HeadPos;
                case PosType.GROUND:
                    return self.GroundPos;
                case PosType.FRONT:
                    return self.ChannelPos;
                case PosType.CENTER:
                    return self.CenterPos;
                case PosType.LEFTHAND:
                    return self.LeftHeadPos;
                case PosType.RIGHTTHAND:
                    return self.RightHeadPos;
                case PosType.WEAPONSTART:
                    return self.WeaponStartPos;
                case PosType.WEAPONCENTER:
                    return self.WeaponCenterPos;
                case PosType.WEAPONEND:
                    return self.WeaponEndPos;
            }

            return null;
        }
    }
}