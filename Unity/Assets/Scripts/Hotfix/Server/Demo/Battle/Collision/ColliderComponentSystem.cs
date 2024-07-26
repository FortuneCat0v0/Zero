using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Common;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(ColliderComponent))]
    [FriendOf(typeof(ColliderComponent))]
    public static partial class ColliderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ColliderComponent self)
        {
            self.WorldComponent = self.Root().GetComponent<CollisionWorldComponent>();
        }

        [EntitySystem]
        private static void Awake(this ColliderComponent self, CreateColliderArgs args)
        {
            self.WorldComponent = self.Root().GetComponent<CollisionWorldComponent>();
            self.BelongToUnit = args.BelontToUnit;
            self.SyncPosToBelongUnit = args.FollowUnitPos;
            self.SyncRotToBelongUnit = args.FollowUnitRot;
            self.ColliderConfig = ColliderConfigCategory.Instance.Get(args.ColliderConfigId);
            self.ActionEvent = args.ActionEvent;
            self.Params = args.Params;

            Unit selfUnit = self.GetParent<Unit>();
            if (args.FollowUnitPos)
            {
                selfUnit.Position = self.BelongToUnit.Position + args.Offset;
            }
            else
            {
                selfUnit.Position = args.TargetPos;
            }

            if (args.FollowUnitRot)
            {
                selfUnit.Rotation = self.BelongToUnit.Rotation;
            }
            else
            {
                selfUnit.Rotation = quaternion.Euler(new float3(0, args.Angle, 0));
            }

            self.CreateCollider();
            self.SyncBody();
        }

        [EntitySystem]
        private static void FixedUpdate(this ColliderComponent self)
        {
            Unit unit = self.GetParent<Unit>();

            if (self.SyncPosToBelongUnit)
            {
                unit.Position = self.BelongToUnit.Position;
            }

            if (self.SyncRotToBelongUnit)
            {
                unit.Rotation = self.BelongToUnit.Rotation;
            }

            self.SyncBody();
        }

        [EntitySystem]
        private static void Destroy(this ColliderComponent self)
        {
            self.WorldComponent.AddBodyTobeDestroyed(self.Body);
        }

        public static void CreateCollider(this ColliderComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            self.Body = self.WorldComponent.CreateDynamicBody(new Vector2(unit.Position.x, unit.Position.z));
            switch (self.ColliderConfig.ColliderType)
            {
                case EColliderType.Circle:
                    self.Body.CreateCircleFixture(self.ColliderConfig.Radius, self.ColliderConfig.Offset.NewVector2(), self.ColliderConfig.IsSensor, unit);

                    break;
                case EColliderType.Box:
                    self.Body.CreateBoxFixture(self.ColliderConfig.HX, self.ColliderConfig.HY, self.ColliderConfig.Offset.NewVector2(), 0,
                        self.ColliderConfig.IsSensor, unit);

                    break;
                case EColliderType.Polygon:
                    foreach (var verxtPoint in self.ColliderConfig.FinalPoints)
                    {
                        self.Body.CreatePolygonFixture(verxtPoint.NewListVector2(), self.ColliderConfig.IsSensor, unit);
                    }

                    break;
            }
        }

        /// <summary>
        /// 血量变化的时候，动态更新角色碰撞框的大小
        /// </summary>
        /// <param name="self"></param>
        /// <param name="radius"></param>
        public static void SetBodyCircleRadius(this ColliderComponent self, float radius)
        {
            if (self.Body.FixtureList.Count > 0)
            {
                Shape shape = self.Body.FixtureList[0].Shape;
                if (shape is CircleShape circle)
                {
                    circle.Radius = radius;
                }
            }
        }

        private static void SyncBody(this ColliderComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();
            self.Body.SetTransform(new Vector2(selfUnit.Position.x, selfUnit.Position.z), MathHelper.Angle(new float3(0, 0, 1), selfUnit.Forward));
        }

        public static void SetColliderBodyState(this ColliderComponent self, bool state)
        {
            self.Body.IsEnabled = state;
        }
    }
}