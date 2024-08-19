
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class EffectConfig : BeanBase
    {
        public EffectConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Desc = _buf.ReadString();
            AssetPath = _buf.ReadString();
            Life = _buf.ReadInt();
            FollowUnit = _buf.ReadBool();
            UnitPosType = (EUnitPosType)_buf.ReadInt();
            SyncRot = _buf.ReadBool();

            PostInit();
        }

        public static EffectConfig DeserializeEffectConfig(ByteBuf _buf)
        {
            return new EffectConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 描述
        /// </summary>
        public readonly string Desc;

        /// <summary>
        /// 描述
        /// </summary>
        public readonly string AssetPath;

        /// <summary>
        /// 特效执行时间(毫秒)
        /// </summary>
        public readonly int Life;

        /// <summary>
        /// 是否跟随物体
        /// </summary>
        public readonly bool FollowUnit;

        /// <summary>
        /// 跟随的位置
        /// </summary>
        public readonly EUnitPosType UnitPosType;

        /// <summary>
        /// 同步旋转
        /// </summary>
        public readonly bool SyncRot;

        public const int __ID__ = -682668973;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Desc:" + Desc + ","
            + "AssetPath:" + AssetPath + ","
            + "Life:" + Life + ","
            + "FollowUnit:" + FollowUnit + ","
            + "UnitPosType:" + UnitPosType + ","
            + "SyncRot:" + SyncRot + ","
            + "}";
        }

        partial void PostInit();
    }
}
