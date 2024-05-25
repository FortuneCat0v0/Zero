using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class Skill : Entity, IAwake, IAwake<int, int>, IDestroy, ISerializeToEntity
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<SkillComponent>().Unit;

        public int SkillConfigId { get; set; }

        public int SkillLevel { get; set; }

        // public int AbstractIndex;
        [BsonIgnore]
        public ESkillAbstractType SkillAbstractType => this.SkillConfig.SkillAbstractType;

        [BsonIgnore]
        public SkillConfig SkillConfig => SkillConfigCategory.Instance.Get(this.SkillConfigId, this.SkillLevel);

        /// <summary>
        /// 技能释放开始时间戳
        /// </summary>
        [BsonIgnore]
        public long SpellStartTime { get; set; }

        /// <summary>
        /// 技能结束完成释放时间
        /// </summary>
        [BsonIgnore]
        public long SpellEndTime { get; set; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        [BsonIgnore]
        public int CD { get; set; }

        /// <summary>
        /// 当前冷却时间
        /// </summary>
        [BsonIgnore]
        public long CurrentCD => this.SpellStartTime + this.CD - TimeInfo.Instance.ClientNow();
    }
}