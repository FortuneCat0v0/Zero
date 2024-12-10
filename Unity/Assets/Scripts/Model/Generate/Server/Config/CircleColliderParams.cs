
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
    public sealed partial class CircleColliderParams : ColliderParams
    {
        public CircleColliderParams(ByteBuf _buf) : base(_buf) 
        {
            Radius = _buf.ReadFloat();
            Offset = ExternalTypeUtil.NewVector2(vector2.Deserializevector2(_buf));

            PostInit();
        }

        public static CircleColliderParams DeserializeCircleColliderParams(ByteBuf _buf)
        {
            return new CircleColliderParams(_buf);
        }

        public readonly float Radius;

        public readonly System.Numerics.Vector2 Offset;


        public const int __ID__ = 512739242;
        public override int GetTypeId() => __ID__;

        public override void ResolveRef()
        {
            base.ResolveRef();
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "Radius:" + Radius + ","
            + "Offset:" + Offset + ","
            + "}";
        }

        partial void PostInit();
    }
}
