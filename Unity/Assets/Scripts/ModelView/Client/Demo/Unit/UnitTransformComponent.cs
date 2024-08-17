using UnityEngine;

namespace ET.Client
{
    public enum PosType
    {
        /// <summary>
        /// 头顶
        /// </summary>
        HEAD,

        /// <summary>
        /// 正中央
        /// </summary>
        CENTER,

        /// <summary>
        /// 底部
        /// </summary>
        GROUND,

        /// <summary>
        /// 正前方
        /// </summary>
        FRONT,

        /// <summary>
        /// 左手
        /// </summary>
        LEFTHAND,

        /// <summary>
        /// 右手
        /// </summary>
        RIGHTTHAND,

        /// <summary>
        /// 武器前端
        /// </summary>
        WEAPONSTART,

        /// <summary>
        /// 武器中间
        /// </summary>
        WEAPONCENTER,

        /// <summary>
        /// 武器末端
        /// </summary>
        WEAPONEND,
    }

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