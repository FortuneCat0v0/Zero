using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET
{
    public enum ESkillState
    {
        Normal,
        Execute
    }

    public enum ESkillOpType
    {
        Add,
        Remove,
        Interrupt,
        SetSkillGrid,
        UpLevel
    }

    [ChildOf]
    public class Skill : Entity, IAwake, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int SkillConfigId { get; set; }

        public long SpellStartTime { get; set; }

        public long SpellEndTime { get; set; }

        [BsonIgnore]
        public ESkillState SkillState { get; set; }

        [BsonIgnore]
        public long TargetUnitId { get; set; }

        [BsonIgnore]
        public float Angle { get; set; }

        [BsonIgnore]
        public float3 Position { get; set; }

        [BsonIgnore]
        public long Timer;

        [BsonIgnore]
        public int CurrentActionEventIndex { get; set; }

        [BsonIgnore]
        public ETCancellationToken CancellationToken { get; set; }

        [BsonIgnore]
        public Unit OwnerUnit => this.GetParent<SkillComponent>().GetParent<Unit>();

        [BsonIgnore]
        public SkillConfig SkillConfig
        {
            get
            {
                if (this.skillConfig == null)
                {
                    this.skillConfig = SkillConfigCategory.Instance.Get(this.SkillConfigId);
                }

                if (this.skillConfig.Id != this.SkillConfigId)
                {
                    this.skillConfig = SkillConfigCategory.Instance.Get(this.SkillConfigId);
                }

                return this.skillConfig;
            }
        }

        [BsonIgnore]
        private SkillConfig skillConfig;

        [BsonIgnore]
        public long EffectId;
    }
}