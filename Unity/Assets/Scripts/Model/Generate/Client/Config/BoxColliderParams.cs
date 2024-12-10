
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
    public sealed partial class BoxColliderParams : ColliderParams
    {
        public BoxColliderParams(ByteBuf _buf) : base(_buf) 
        {
            HX = _buf.ReadFloat();
            HY = _buf.ReadFloat();
            Offset = vector2.Deserializevector2(_buf);

            PostInit();
        }

        public static BoxColliderParams DeserializeBoxColliderParams(ByteBuf _buf)
        {
            return new BoxColliderParams(_buf);
        }

        public readonly float HX;

        public readonly float HY;

        public readonly vector2 Offset;


        public const int __ID__ = -2055945947;
        public override int GetTypeId() => __ID__;

        public override void ResolveRef()
        {
            base.ResolveRef();
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "HX:" + HX + ","
            + "HY:" + HY + ","
            + "Offset:" + Offset + ","
            + "}";
        }

        partial void PostInit();
    }
}