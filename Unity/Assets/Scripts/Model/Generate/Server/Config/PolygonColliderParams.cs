
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
    public sealed partial class PolygonColliderParams : ColliderParams
    {
        public PolygonColliderParams(ByteBuf _buf) : base(_buf) 
        {
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);FinalPoints = new System.Collections.Generic.List<System.Collections.Generic.List<System.Numerics.Vector2>>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { System.Collections.Generic.List<System.Numerics.Vector2> _e0;  {int n1 = System.Math.Min(_buf.ReadSize(), _buf.Size);_e0 = new System.Collections.Generic.List<System.Numerics.Vector2>(n1);for(var i1 = 0 ; i1 < n1 ; i1++) { System.Numerics.Vector2 _e1;  _e1 = ExternalTypeUtil.NewVector2(vector2.Deserializevector2(_buf)); _e0.Add(_e1);}} FinalPoints.Add(_e0);}}

            PostInit();
        }

        public static PolygonColliderParams DeserializePolygonColliderParams(ByteBuf _buf)
        {
            return new PolygonColliderParams(_buf);
        }

        public readonly System.Collections.Generic.List<System.Collections.Generic.List<System.Numerics.Vector2>> FinalPoints;


        public const int __ID__ = -1220707756;
        public override int GetTypeId() => __ID__;

        public override void ResolveRef()
        {
            base.ResolveRef();
            
        }

        public override string ToString()
        {
            return "{ "
            + "FinalPoints:" + Luban.StringUtil.CollectionToString(FinalPoints) + ","
            + "}";
        }

        partial void PostInit();
    }
}
