using Box2DSharp.Collision.Collider;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;
using System.Collections.Generic;
using System.Numerics;
using World = Box2DSharp.Dynamics.World;

namespace ET.Server
{
    [EntitySystemOf(typeof(CollisionWorldComponent))]
    [FriendOf(typeof(CollisionWorldComponent))]
    public static partial class CollisionWorldComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CollisionWorldComponent self)
        {
            self.World = CollisionHelper.CreateWorld(new Vector2(0, 0));
            CollisionListenerComponent collisionListener = self.Root().AddComponent<CollisionListenerComponent>();
            self.World.SetContactListener(collisionListener);
        }

        /// <summary>
        /// 每帧驱动更新碰撞检测
        /// </summary>
        /// <param name="self"></param>
        [EntitySystem]
        private static void FixedUpdate(this CollisionWorldComponent self)
        {
            foreach (var body in self.BodyToDestroy)
            {
                self.World.DestroyBody(body);
            }

            self.BodyToDestroy.Clear();
            self.World.Step(DefineCore.FixedDeltaTime, self.VelocityIteration, self.PositionIteration);
        }

        [EntitySystem]
        private static void Destroy(this CollisionWorldComponent self)
        {
        }

        public static Body CreateStaticBody(this CollisionWorldComponent self, Vector2 position)
        {
            return self.World.CreateBody(new BodyDef() { BodyType = BodyType.StaticBody, Position = position });
        }

        public static Body CreateKinematicBody(this CollisionWorldComponent self, Vector2 position)
        {
            return self.World.CreateBody(new BodyDef() { BodyType = BodyType.KinematicBody, AllowSleep = false, Position = position });
        }

        public static Body CreateDynamicBody(this CollisionWorldComponent self, Vector2 position)
        {
            return self.World.CreateBody(new BodyDef() { BodyType = BodyType.DynamicBody, AllowSleep = false, Position = position });
        }

        public static void AddBodyTobeDestroyed(this CollisionWorldComponent self, Body body)
        {
            self.BodyToDestroy.Add(body);
        }
    }
}