using System.Numerics;
using Box2DSharp.Collision.Shapes;
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
            self.CollisionWorldComponent = self.Root().GetComponent<CollisionWorldComponent>();
        }

        [EntitySystem]
        private static void Awake(this ColliderComponent self, CreateColliderParams createColliderParams)
        {
            self.CollisionWorldComponent = self.Root().GetComponent<CollisionWorldComponent>();
            self.BelongToUnit = createColliderParams.BelontToUnit;
            self.SyncPosToBelongUnit = createColliderParams.FollowUnitPos;
            self.SyncRotToBelongUnit = createColliderParams.FollowUnitRot;
            self.ColliderConfig = ColliderConfigCategory.Instance.Get(createColliderParams.ColliderConfigId);
            self.Skill = createColliderParams.Skill;
            self.CollisionHandler = createColliderParams.CollisionHandler;
            self.Params = createColliderParams.Params;

            Unit selfUnit = self.GetParent<Unit>();
            if (createColliderParams.FollowUnitPos)
            {
                selfUnit.Position = createColliderParams.BelontToUnit.Position + createColliderParams.Offset;
            }
            else
            {
                selfUnit.Position = createColliderParams.TargetPos;
            }

            if (createColliderParams.FollowUnitRot)
            {
                selfUnit.Rotation = createColliderParams.BelontToUnit.Rotation;
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

            Unit belongToUnit = self.BelongToUnit;
            if (self.SyncPosToBelongUnit)
            {
                unit.Position = belongToUnit.Position;
            }

            if (self.SyncRotToBelongUnit)
            {
                unit.Rotation = belongToUnit.Rotation;
            }

            self.SyncBody();
        }

        [EntitySystem]
        private static void Destroy(this ColliderComponent self)
        {
            Log.Warning("Destroy 碰撞体");
            CollisionWorldComponent collisionWorldComponent = self.CollisionWorldComponent;
            collisionWorldComponent?.AddBodyTobeDestroyed(self.Body);
        }

        public static void CreateCollider(this ColliderComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            CollisionWorldComponent collisionWorldComponent = self.CollisionWorldComponent;
            self.Body = collisionWorldComponent.CreateDynamicBody(new Vector2(unit.Position.x, unit.Position.z));
            switch (self.ColliderConfig.ColliderType)
            {
                case EColliderType.Circle:
                    self.Body.CreateCircleFixture(self.ColliderConfig.Radius, self.ColliderConfig.Offset.NewVector2(), self.ColliderConfig.IsSensor,
                        unit);

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

        public static void SyncBody(this ColliderComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();

            self.SetColliderBodyPos(new Vector2(selfUnit.Position.x, selfUnit.Position.z));
            self.SetColliderBodyAngle(MathHelper.QuaternionToEulerAngle_Y(selfUnit.Rotation));
        }

        public static void SyncUnit(this ColliderComponent self)
        {
            Unit selfUnit = self.GetParent<Unit>();

            selfUnit.Position = new float3(self.Body.GetPosition().X, selfUnit.Position.y, self.Body.GetPosition().Y);
            selfUnit.Rotation = quaternion.Euler(0, math.radians(self.Body.GetAngle()), 0);
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