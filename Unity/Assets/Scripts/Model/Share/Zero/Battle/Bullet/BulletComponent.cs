using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class BulletComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        public Unit OwnerUnit { get; set; }
        public Skill OwnerSkill { get; set; }
        public long EndTime;
    }
}