using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Skill))]
    public class SkillTimelineComponent : Entity, IAwake<int, int>, IFixedUpdate, ITransfer
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Skill>().Unit;

        public SkillConfig SkillConfig;
    }
}