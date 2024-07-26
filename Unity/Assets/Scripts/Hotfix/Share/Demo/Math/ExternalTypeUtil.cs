using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ET
{
    public static class ExternalTypeUtil
    {
        public static Vector2 NewVector2(this vector2 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static Vector3 NewVector3(this vector3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static Vector4 NewVector4(this vector4 v)
        {
            return new Vector4(v.X, v.Y, v.Z, v.W);
        }

        public static List<Vector2> NewListVector2(this List<vector2> list)
        {
            return list.Select(v => v.NewVector2()).ToList();
        }

        public static List<Vector3> NewListVector3(this List<vector3> list)
        {
            return list.Select(v => v.NewVector3()).ToList();
        }
    }
}