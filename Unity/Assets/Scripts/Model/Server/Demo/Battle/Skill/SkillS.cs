using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET.Server
{
    [ChildOf]
    public class SkillS : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int SkillConfigId { get; set; }

        public long SpellStartTime { get; set; }

        public long SpellEndTime { get; set; }

        [BsonIgnore]
        public int CD { get; set; }

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
        public Unit OwnerUnit => this.GetParent<SkillSComponent>().GetParent<Unit>();

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
        public SkillSHandler SkillSHandler;

        [BsonIgnore]
        public bool Active { get; set; }
    }
}