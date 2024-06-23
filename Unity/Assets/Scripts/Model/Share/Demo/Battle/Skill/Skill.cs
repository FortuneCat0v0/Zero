using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET
{
    public enum ESkillState
    {
        Normal,
        Execute
    }

    [ChildOf]
    public class Skill : Entity, IAwake, IAwake<int, int>, IDestroy, ISerializeToEntity
    {
        public int SkillConfigId { get; set; }

        public int SkillLevel { get; set; }

        public long SpellStartTime { get; set; }

        public long SpellEndTime { get; set; }

        [BsonIgnore]
        public ESkillState SkillState;

        [BsonIgnore]
        public long TargetUnitId { get; set; }

        [BsonIgnore]
        public float3 Position { get; set; }

        [BsonIgnore]
        public float3 Direction { get; set; }

        [BsonIgnore]
        public long Timer;

        [BsonIgnore]
        public int CurrentActionEventIndex { get; set; }

        [BsonIgnore]
        public ETCancellationToken CancellationToken { get; set; }

        [BsonIgnore]
        public Unit OwnerUnit => this.GetParent<SkillComponent>().Unit;

        [BsonIgnore]
        public SkillConfig SkillConfig
        {
            get
            {
                if (this.skillConfig == null)
                {
                    this.skillConfig = SkillConfigCategory.Instance.Get(this.SkillConfigId, this.SkillLevel);
                }

                if (this.skillConfig.Id != this.SkillConfigId || this.skillConfig.Level != this.SkillLevel)
                {
                    this.skillConfig = SkillConfigCategory.Instance.Get(this.SkillConfigId, this.SkillLevel);
                }

                return this.skillConfig;
            }
        }

        [BsonIgnore]
        private SkillConfig skillConfig;
    }
}