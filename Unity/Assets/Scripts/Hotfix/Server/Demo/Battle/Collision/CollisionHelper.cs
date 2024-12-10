using System;
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
        /// <param name="userData">用户自定义信息</param>
        /// <param name="layer"></param>
        public static void CreateBoxFixture(this Body self, float hx, float hy, Vector2 offset, float angle, bool isSensor, ushort layer,
        object userData)
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
        public static void CreateCircleFixture(this Body self, float radius, Vector2 offset, bool isSensor, ushort layer, object userData)
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
        public static void CreatePolygonFixture(this Body self, List<Vector2> points, bool isSensor, ushort layer, object userData)
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

        /// <summary>
        /// 为刚体挂载一个扇形（多边形）碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="radius">扇形的半径</param>
        /// <param name="startAngle">扇形的结束角度（角度制）。</param>
        /// <param name="endAngle">扇形的起始角度（角度制）。</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="layer"></param>
        /// <param name="userData"></param>
        public static void CreateSectorFixture(this Body self, float radius, float startAngle, float endAngle, bool isSensor, ushort layer,
        object userData)
        {
            // 计算扇形的顶点
            List<Vector2> points = new List<Vector2>();

            // 计算角度范围
            float angleRange = endAngle - startAngle;

            // 步长，多少度一个三角形
            float maxAngleStep = 10f;

            // 计算适当的分段数
            int segments = (int)(angleRange / maxAngleStep);
            segments = Math.Max(segments, 1); // 至少一个分段

            // 将角度转化为弧度（角度 * π / 180）
            float startRad = MathF.PI * startAngle / 180f;
            float angleStep = MathF.PI * maxAngleStep / 180f; // 步长转换为弧度

            // 计算顶点位置
            for (int i = 0; i <= segments; i++)
            {
                float angle = startRad + i * angleStep;
                float x = radius * MathF.Cos(angle);
                float y = radius * MathF.Sin(angle);
                points.Add(new Vector2(x, y));
            }

            // 确保至少有一个三角形扇形
            if (points.Count > 1)
            {
                // 扇形的中心点
                Vector2 center = Vector2.Zero;

                // 遍历点并生成每个扇形的小三角形
                for (int i = 0; i < points.Count - 1; i++)
                {
                    List<Vector2> p = new List<Vector2>
                    {
                        points[i], // 当前点
                        points[i + 1], // 下一个点
                        center // 中心点
                    };
                    self.CreatePolygonFixture(p, isSensor, layer, userData);
                }
            }
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