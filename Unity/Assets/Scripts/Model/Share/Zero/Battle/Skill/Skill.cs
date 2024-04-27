using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class Skill : Entity, IAwake, IAwake<int, int>, IDestroy, ITransfer
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<SkillComponent>().Unit;

        public int SkillConfigId;

        public int SkillLevel;

        // public int AbstractIndex;
        [BsonIgnore]
        public ESkillAbstractType AbstractType => (ESkillAbstractType)this.SkillConfig.AbstractType;

        [BsonIgnore]
        public SkillConfig SkillConfig => SkillConfigCategory.Instance.Get(this.SkillConfigId, this.SkillLevel);

        /// <summary>
        /// 技能释放开始时间戳
        /// </summary>
        [BsonIgnore]
        public long SpellStartTime;

        /// <summary>
        /// 技能结束完成释放时间
        /// </summary>
        [BsonIgnore]
        public long SpellEndTime;

        /// <summary>
        /// 冷却时间
        /// </summary>
        [BsonIgnore]
        public int CD;

        /// <summary>
        /// 当前冷却时间
        /// </summary>
        [BsonIgnore]
        public int CurrentCD => (int)(this.SpellStartTime + this.CD - TimeInfo.Instance.ClientNow());
    }
}