
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
    public sealed partial class ItemConfig : BeanBase
    {
        public ItemConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Type = _buf.ReadInt();
            EquipPosition = _buf.ReadInt();
            Quality = _buf.ReadInt();
            Icon = _buf.ReadString();
            Description = _buf.ReadString();

            PostInit();
        }

        public static ItemConfig DeserializeItemConfig(ByteBuf _buf)
        {
            return new ItemConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 类型
        /// </summary>
        public readonly int Type;

        public readonly int EquipPosition;

        public readonly int Quality;

        public readonly string Icon;

        public readonly string Description;

        public const int __ID__ = -764023723;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Type:" + Type + ","
            + "EquipPosition:" + EquipPosition + ","
            + "Quality:" + Quality + ","
            + "Icon:" + Icon + ","
            + "Description:" + Description + ","
            + "}";
        }

        partial void PostInit();
    }
}
