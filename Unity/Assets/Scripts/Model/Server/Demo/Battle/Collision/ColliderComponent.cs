using System.Collections.Generic;
using Box2DSharp.Dynamics;
using Unity.Mathematics;

namespace ET.Server
{
    public struct CreateColliderParams
    {
        public Unit BelongToUnit;
        public int ColliderConfigId;

        public bool FollowUnitPos;
        public bool FollowUnitRot;
        public float3 Offset;

        public float3 TargetPos;
        public float Angle;

        public SkillS SkillS;
        public string CollisionHandler;
        public List<int> Params;

        public CreateColliderParams(
        Unit belongToUnit,
        int colliderConfigId,
        bool followUnitPos = false,
        bool followUnitRot = false,
        float3 offset = default,
        float3 targetPos = default,
        float angle = 0,
        SkillS skillS = null,
        string collisionHandler = null,
        List<int> paramsList = null)
        {
            BelongToUnit = belongToUnit;
            ColliderConfigId = colliderConfigId;
            FollowUnitPos = followUnitPos;
            FollowUnitRot = followUnitRot;
            Offset = offset;
            TargetPos = targetPos;
            Angle = angle;
            SkillS = skillS;
            CollisionHandler = collisionHandler;
            Params = paramsList;
        }
    }

    [ComponentOf(typeof(Unit))]
    public class ColliderComponent : Entity, IAwake, IAwake<CreateColliderParams>, IFixedUpdate, IDestroy
    {
        private EntityRef<Unit> belongToUnit;

        /// <summary>
        /// 所归属的Unit，也就是产出碰撞体的Unit，
        /// 比如诺克放一个Q，那么BelongUnit就是诺克
        /// 需要注意的是，如果这个碰撞体需要同步位置，同步目标是Parent，而不是这个BelongToUnit
        /// </summary>
        public Unit BelongToUnit { get => this.belongToUnit; set => this.belongToUnit = value; }

        private EntityRef<CollisionWorldComponent> collisionWorldComponent;
        public CollisionWorldComponent CollisionWorldComponent { get => this.collisionWorldComponent; set => this.collisionWorldComponent = value; }

        public Body Body;

        public bool SyncPosToBelongUnit;

        public bool SyncRotToBelongUnit;

        public ColliderConfig ColliderConfig;

        private EntityRef<SkillS> skillS;
        public SkillS SkillC { get => this.skillS; set => this.skillS = value; }
        public string CollisionHandler { get; set; }
        public List<int> Params { get; set; }

        //-----------执行时-------------
        public List<long> UnitIds { get; set; } = new();
        public Dictionary<long, long> UnitLastTriggerTimeDict { get; set; } = new();
    }
}