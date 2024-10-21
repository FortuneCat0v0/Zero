using System;
using System.Numerics;
using Box2DSharp.Dynamics;

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
            CollisionListenerComponent collisionListener = self.Root().GetComponent<CollisionListenerComponent>();
            if (collisionListener == null)
            {
                Log.Error("没有添加组件 CollisionListenerComponent");
                return;
            }

            self.World.SetContactListener(collisionListener);
        }

        [EntitySystem]
        private static void FixedUpdate(this CollisionWorldComponent self)
        {
            if (self.World == null)
            {
                return;
            }

            foreach (var body in self.BodyToDestroy)
            {
                self.World.DestroyBody(body);
            }

            self.BodyToDestroy.Clear();
            try
            {
                self.World.Step(DefineCore.FixedDeltaTime, self.VelocityIteration, self.PositionIteration);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        [EntitySystem]
        private static void Destroy(this CollisionWorldComponent self)
        {
            self.World.Dispose();
            self.World = null;
            self.BodyToDestroy.Clear();
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