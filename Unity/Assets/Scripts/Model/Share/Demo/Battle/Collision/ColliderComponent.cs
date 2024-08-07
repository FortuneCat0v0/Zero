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
    public struct CreateColliderArgs
    {
        public Unit BelontToUnit;
        public bool FollowUnitPos;
        public bool FollowUnitRot;
        public float3 Offset;

        public float3 TargetPos;
        public float Angle;

        public int ColliderConfigId;
        public string ActionEvent;
        public List<int> Params;
    }

    [ComponentOf(typeof(Unit))]
    public class ColliderComponent : Entity, IAwake, IAwake<CreateColliderArgs>, IFixedUpdate, IDestroy
    {
        /// <summary>
        /// 所归属的Unit，也就是产出碰撞体的Unit，
        /// 比如诺克放一个Q，那么BelongUnit就是诺克
        /// 需要注意的是，如果这个碰撞体需要同步位置，同步目标是Parent，而不是这个BelongToUnit
        /// </summary>
        public Unit BelongToUnit { get; set; }

        public CollisionWorldComponent WorldComponent { get; set; }

        public Body Body;

        public bool SyncPosToBelongUnit;

        public bool SyncRotToBelongUnit;

        public ColliderConfig ColliderConfig;

        public string CollisionHandler { get; set; }
        public List<int> Params;
        public long LastTriggerTime;
        public List<long> Units;
    }
}