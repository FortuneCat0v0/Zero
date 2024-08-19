using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UnitTransformComponent : Entity, IAwake
    {
        public Transform HeadPos;
        public Transform ChannelPos;
        public Transform GroundPos;
        public Transform CenterPos;
        public Transform LeftHeadPos;
        public Transform RightHeadPos;
        public Transform WeaponStartPos;
        public Transform WeaponCenterPos;
        public Transform WeaponEndPos;
    }
}