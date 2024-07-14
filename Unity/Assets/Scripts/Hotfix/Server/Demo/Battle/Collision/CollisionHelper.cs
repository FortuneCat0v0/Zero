using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ET.Server
{
    public static class CollisionHelper
    {
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
        public static void CreateBoxFixture(this Body self, float hx, float hy, Vector2 offset, float angle, bool isSensor, object userData)
        {
            PolygonShape m_BoxShape = new();
            m_BoxShape.SetAsBox(hx, hy, offset, angle);
            FixtureDef fixtureDef = new();
            fixtureDef.IsSensor = isSensor;
            fixtureDef.Shape = m_BoxShape;
            fixtureDef.UserData = userData;
            self.CreateFixture(fixtureDef);
        }

        /// <summary>
        /// 为刚体挂载一个圆形碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="radius">半径</param>
        /// <param name="offset">偏移量</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="userData">用户自定义信息</param>
        public static void CreateCircleFixture(this Body self, float radius, Vector2 offset, bool isSensor, object userData)
        {
            CircleShape m_CircleShape = new();
            m_CircleShape.Radius = radius;
            m_CircleShape.Position = offset;
            FixtureDef fixtureDef = new();
            fixtureDef.IsSensor = isSensor;
            fixtureDef.Shape = m_CircleShape;
            fixtureDef.UserData = userData;
            self.CreateFixture(fixtureDef);
        }

        /// <summary>
        /// 为刚体挂载一个多边形碰撞体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="points">顶点数据</param>
        /// <param name="isSensor">是否为触发器</param>
        /// <param name="userData">用户自定义信息</param>
        public static void CreatePolygonFixture(this Body self, List<Vector2> points, bool isSensor, object userData)
        {
            PolygonShape m_PolygonShape = new();
            m_PolygonShape.Set(points.ToArray());
            FixtureDef fixtureDef3 = new();
            fixtureDef3.IsSensor = isSensor;
            fixtureDef3.Shape = m_PolygonShape;
            fixtureDef3.UserData = userData;
            self.CreateFixture(fixtureDef3);
        }

        public static Box2DSharp.Dynamics.World CreateWorld(Vector2 gravity)
        {
            return new Box2DSharp.Dynamics.World(gravity);
        }
    }
}