using System.Numerics;
using Box2DSharp.Collision.Shapes;
using DotRecast.Detour.Dynamic.Colliders;
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
            self.CollisionWorldComponent = self.Scene().GetComponent<CollisionWorldComponent>();
        }

        [EntitySystem]
        private static void Awake(this ColliderComponent self, CreateColliderParams createColliderParams)
        {
            self.CollisionWorldComponent = self.Scene().GetComponent<CollisionWorldComponent>();
            self.BelongToUnit = createColliderParams.BelongToUnit;
            self.SyncPosToBelongUnit = createColliderParams.FollowUnitPos;
            self.SyncRotToBelongUnit = createColliderParams.FollowUnitRot;
            self.ColliderParams = createColliderParams.ColliderParams;
            self.Layer = createColliderParams.Layer;
            self.SkillC = createColliderParams.Skill;
            self.CollisionHandler = createColliderParams.CollisionHandler;

            Unit selfUnit = self.GetParent<Unit>();
            if (createColliderParams.FollowUnitPos)
            {
                selfUnit.Position = createColliderParams.BelongToUnit.Position + createColliderParams.Offset;
            }
            else
            {
                selfUnit.Position = createColliderParams.TargetPos;
            }

            if (createColliderParams.FollowUnitRot)
            {
                selfUnit.Rotation = createColliderParams.BelongToUnit.Rotation;
            }
            else
            {
                selfUnit.Rotation = quaternion.Euler(0, math.radians(createColliderParams.Angle), 0);
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
            self.UnitIds.Clear();
            self.UnitLastTriggerTimeDict.Clear();
            
            Log.Warning("Destroy 碰撞体");
            self.CollisionWorldComponent?.AddBodyTobeDestroyed(self.Body);
        }

        private static void CreateCollider(this ColliderComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            self.Body = self.CollisionWorldComponent.CreateDynamicBody(new Vector2(unit.Position.x, unit.Position.z));
            switch (self.ColliderParams)
            {
                case CircleColliderParams colliderParams:
                    self.Body.CreateCircleFixture(colliderParams.Radius, Vector2.Zero, true, self.Layer, unit);
                    break;
                case BoxColliderParams colliderParams:
                    self.Body.CreateBoxFixture(colliderParams.HX, colliderParams.HY, Vector2.Zero, 0, true, self.Layer, unit);
                    break;
                case PolygonColliderParams colliderParams:
                {
                    foreach (var points in colliderParams.FinalPoints)
                    {
                        self.Body.CreatePolygonFixture(points, true, self.Layer, unit);
                    }

                    break;
                }
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
                Box2DSharp.Collision.Shapes.Shape shape = self.Body.FixtureList[0].Shape;
                if (shape is CircleShape circle)
                {
                    circle.Radius = radius;
                }
            }
        }

        public static void SyncBody(this ColliderComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();

            self.SetColliderBodyTransform(new(selfUnit.Position.x, selfUnit.Position.z), MathHelper.QuaternionToEulerAngle_Y(selfUnit.Rotation));
        }

        public static void SyncUnit(this ColliderComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();

            selfUnit.Position = new float3(self.Body.GetPosition().X, selfUnit.Position.y, self.Body.GetPosition().Y);
            selfUnit.Rotation = quaternion.Euler(0, math.radians(self.Body.GetAngle()), 0);
        }

        public static void SetColliderBodyTransform(this ColliderComponent self, Vector2 pos, float angle)
        {
            self.Body.SetTransform(pos, angle);
        }

        public static void SetColliderBodyPos(this ColliderComponent self, Vector2 pos)
        {
            self.Body.SetTransform(pos, self.Body.GetAngle());
        }

        public static void SetColliderBodyAngle(this ColliderComponent self, float angle)
        {
            self.Body.SetTransform(self.Body.GetPosition(), angle);
        }

        public static void SetColliderBodyState(this ColliderComponent self, bool state)
        {
            self.Body.IsEnabled = state;
        }
    }
}