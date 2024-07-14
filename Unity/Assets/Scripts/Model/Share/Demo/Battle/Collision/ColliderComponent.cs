using System;
using System.Collections.Generic;
using System.Numerics;
using Box2DSharp.Collision.Collider;
using Box2DSharp.Collision.Shapes;
using Box2DSharp.Dynamics;
using Box2DSharp.Dynamics.Contacts;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Unity.Mathematics;

namespace ET
{
    public struct CreateSkillColliderArgs
    {
        public Unit BelontToUnit;
        public bool FollowUnitPos;
        public bool FollowUnitRot;
        public float3 TargetPos;

        public EColliderType ColliderType;
        public bool isSensor;
        public float3 Offset;

        // 矩形碰撞体的数据
        public float hx;
        public float hy;
        public float Angle;

        // 圆形碰撞体的数据
        public float Radius;

        // 多边形碰撞体的数据
        public List<List<Vector2>> FinalPoints;
        public int PointCount;
    }

    public struct CreateHeroColliderArgs
    {
        public Unit Unit;
        public ColliderDataStructureBase B2SColliderDataStructureBase;
        public string CollisionHandler;
        public bool FollowUnit;
    }

    public struct ColliderDataStructureBase
    {
        public long id;
        public bool isSensor;
        public EColliderType b2SColliderType;
        public Vector2 finalOffset;
    }

    [ComponentOf(typeof(Unit))]
    public class ColliderComponent : Entity, IAwake, IAwake<CreateSkillColliderArgs>, IAwake<ColliderDataStructureBase>, IFixedUpdate, IDestroy
    {
        /// <summary>
        /// 所归属的Unit，也就是产出碰撞体的Unit，
        /// 比如诺克放一个Q，那么BelongUnit就是诺克
        /// 需要注意的是，如果这个碰撞体需要同步位置，同步目标是Parent，而不是这个BelongToUnit
        /// </summary>
        public Unit BelongToUnit { get; set; }

        public CollisionWorldComponent WorldComponent { get; set; }

        public Body Body;

        public string CollisionHandlerName { get; set; }

        public bool SyncPosToBelongUnit;

        public bool SyncRotToBelongUnit;

        public List<int> Params;
        public long LastTriggerTime;
    }
}