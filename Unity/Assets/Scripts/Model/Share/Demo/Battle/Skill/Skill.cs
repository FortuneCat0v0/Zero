using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public enum SkillState
    {
        Ready,
        Active,
        Cooldown
    }

    [ChildOf]
    public class Skill : Entity, IAwake, IAwake<int, int>, IDestroy, IUpdate, ISerializeToEntity
    {
        public int SkillConfigId { get; set; }

        public int SkillLevel { get; set; }

        [BsonIgnore]
        public EInputType InputType { get; set; }

        [BsonIgnore]
        public int CurrentExecuteSkillIndex { get; set; }

        [BsonIgnore]
        public SkillConfig CurrentExecuteSkillConfig { get; set; }

        [BsonIgnore]
        public int CurrentActionEventIndex { get; set; }

        [BsonIgnore]
        public int NextActionEventIndex { get; set; }

        [BsonIgnore]
        public ETCancellationToken CancellationToken { get; set; }

        [BsonIgnore]
        public SkillState SkillState { get; set; }

        [BsonIgnore]
        public Unit OwnerUnit => this.GetParent<SkillComponent>().Unit;

        [BsonIgnore]
        public SkillConfig SkillConfig => SkillConfigCategory.Instance.Get(this.SkillConfigId, this.SkillLevel);

        [BsonIgnore]
        public long SpellStartTime { get; set; }

        [BsonIgnore]
        public long SpellEndTime { get; set; }
    }
}