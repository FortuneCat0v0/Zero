
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
            EffectType = (EEffectType)_buf.ReadInt();
            BindPoint = _buf.ReadString();

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
        /// 特效类型
        /// </summary>
        public readonly EEffectType EffectType;

        /// <summary>
        /// 绑定位置
        /// </summary>
        public readonly string BindPoint;

        public const int __ID__ = -682668973;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Desc:" + Desc + ","
            + "AssetPath:" + AssetPath + ","
            + "Life:" + Life + ","
            + "EffectType:" + EffectType + ","
            + "BindPoint:" + BindPoint + ","
            + "}";
        }

        partial void PostInit();
    }
}
