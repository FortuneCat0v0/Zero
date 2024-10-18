using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class BulletComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        public Unit Unit => this.GetParent<Unit>();

        private EntityRef<Unit> ownerUnit;
        public Unit OwnerUnit { get => this.ownerUnit; set => this.ownerUnit = value; }
        private EntityRef<Skill> ownerSkill;
        public Skill OwnerSkill { get => this.ownerSkill; set => this.ownerSkill = value; }
        public long EndTime;
    }
}