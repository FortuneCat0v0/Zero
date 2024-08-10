using System.Collections.Generic;
using Box2DSharp.Dynamics;
using Unity.Mathematics;

namespace ET
{
    public struct CreateColliderParams
    {
        public Unit BelontToUnit;
        public bool FollowUnitPos;
        public bool FollowUnitRot;
        public float3 Offset;

        public float3 TargetPos;
        public float Angle;

        public int ColliderConfigId;
        public Skill Skill;
        public string CollisionHandler;
        public List<int> Params;
    }

    [ComponentOf(typeof(Unit))]
    public class ColliderComponent : Entity, IAwake, IAwake<CreateColliderParams>, IFixedUpdate, IDestroy
    {
        /// <summary>
        /// 所归属的Unit，也就是产出碰撞体的Unit，
        /// 比如诺克放一个Q，那么BelongUnit就是诺克
        /// 需要注意的是，如果这个碰撞体需要同步位置，同步目标是Parent，而不是这个BelongToUnit
        /// </summary>
        public EntityRef<Unit> BelongToUnit { get; set; }

        public EntityRef<CollisionWorldComponent> CollisionWorldComponent { get; set; }

        public Body Body;

        public bool SyncPosToBelongUnit;

        public bool SyncRotToBelongUnit;

        public ColliderConfig ColliderConfig;

        public EntityRef<Skill> Skill;
        public string CollisionHandler { get; set; }
        public List<int> Params { get; set; }
        public long LastTriggerTime;
        public List<long> UnitIds { get; set; } = new();
    }
}