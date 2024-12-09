using System.Collections.Generic;
using System.Numerics;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;

namespace ET.Server
{
    public static class CollisionHelper
    {
        // 依次类推，最多 16 个类别
        public const ushort Default = 1 << 0;
        public const ushort Player = 1 << 1;
        public const ushort Monster = 1 << 2;
        public const ushort Area = 1 << 3;
        public const ushort Skill = 1 << 4;

        public const ushort Max = 1 << 15;
        public const ushort All = 0xFFFF;

        public static ushort GetMaskBits(ushort layer)
        {
            return layer switch
            {
                Default => All,
                Player => Monster | Area,
                Monster => Skill,
                Area => Player,
                Skill => Monster,
                _ => All
            };
        }

        /// <summary>
        /// 为刚体挂载一个矩形碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="hx">半宽</param>
        /// <param name="hy">半高</param>
        /// <param name="offset">偏移量</param>
        /// <param name="angle">角度</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="layer"></param>
        /// <param name="userData">用户自定义信息</param>
        public static void CreateBoxFixture(this Body self, float hx, float hy, Vector2 offset, float angle, bool isSensor, object userData,
        ushort layer)
        {
            PolygonShape m_BoxShape = new();
            m_BoxShape.SetAsBox(hx, hy, offset, angle);
            FixtureDef fixtureDef = new();
            fixtureDef.IsSensor = isSensor;
            fixtureDef.Shape = m_BoxShape;
            fixtureDef.UserData = userData;
            fixtureDef.Filter = new()
            {
                CategoryBits = layer,
                MaskBits = GetMaskBits(layer),
                GroupIndex = 0
            };
            self.CreateFixture(fixtureDef);
        }

        /// <summary>
        /// 为刚体挂载一个圆形碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="radius">半径</param>
        /// <param name="offset">偏移量</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="layer"></param>
        /// <param name="userData">用户自定义信息</param>
        public static void CreateCircleFixture(this Body self, float radius, Vector2 offset, bool isSensor, object userData, ushort layer)
        {
            CircleShape m_CircleShape = new();
            m_CircleShape.Radius = radius;
            m_CircleShape.Position = offset;
            FixtureDef fixtureDef = new();
            fixtureDef.IsSensor = isSensor;
            fixtureDef.Shape = m_CircleShape;
            fixtureDef.UserData = userData;
            fixtureDef.Filter = new()
            {
                CategoryBits = layer,
                MaskBits = GetMaskBits(layer),
                GroupIndex = 0
            };
            self.CreateFixture(fixtureDef);
        }

        /// <summary>
        /// 为刚体挂载一个多边形碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="points">顶点数据</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="layer"></param>
        /// <param name="userData">用户自定义信息</param>
        public static void CreatePolygonFixture(this Body self, List<Vector2> points, bool isSensor, object userData, ushort layer)
        {
            PolygonShape m_PolygonShape = new();
            m_PolygonShape.Set(points.ToArray());
            FixtureDef fixtureDef3 = new();
            fixtureDef3.IsSensor = isSensor;
            fixtureDef3.Shape = m_PolygonShape;
            fixtureDef3.UserData = userData;
            fixtureDef3.Filter = new()
            {
                CategoryBits = layer,
                MaskBits = GetMaskBits(layer),
                GroupIndex = 0
            };
            self.CreateFixture(fixtureDef3);
        }

        public static Box2DSharp.Dynamics.World CreateWorld(Vector2 gravity)
        {
            return new Box2DSharp.Dynamics.World(gravity);
        }

        public static bool TestPoint(this Body self, Vector2 point)
        {
            foreach (Fixture fixture in self.FixtureList)
            {
                if (fixture.TestPoint(point))
                {
                    return true;
                }
            }

            return false;
        }
    }
}