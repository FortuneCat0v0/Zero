
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
    public sealed partial class AreaConfig : BeanBase
    {
        public AreaConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Des = _buf.ReadString();
            Point = vector2.Deserializevector2(_buf);
            ColliderConfigId = _buf.ReadInt();
            AreaType = (EAreaType)_buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Params = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Params.Add(_e0);}}

            PostInit();
        }

        public static AreaConfig DeserializeAreaConfig(ByteBuf _buf)
        {
            return new AreaConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 区域名
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 描述
        /// </summary>
        public readonly string Des;

        /// <summary>
        /// 区域坐标点
        /// </summary>
        public readonly vector2 Point;

        /// <summary>
        /// 碰撞体配置信息
        /// </summary>
        public readonly int ColliderConfigId;

        /// <summary>
        /// 类型
        /// </summary>
        public readonly EAreaType AreaType;

        /// <summary>
        /// 参数
        /// </summary>
        public readonly System.Collections.Generic.List<int> Params;


        public const int __ID__ = -1932083633;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef()
        {
            
            
            
            
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Des:" + Des + ","
            + "Point:" + Point + ","
            + "ColliderConfigId:" + ColliderConfigId + ","
            + "AreaType:" + AreaType + ","
            + "Params:" + Luban.StringUtil.CollectionToString(Params) + ","
            + "}";
        }

        partial void PostInit();
    }
}