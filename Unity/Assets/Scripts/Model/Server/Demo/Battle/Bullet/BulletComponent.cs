using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BulletComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        public Unit Unit => this.GetParent<Unit>();

        private EntityRef<Unit> ownerUnit;
        public Unit OwnerUnit { get => this.ownerUnit; set => this.ownerUnit = value; }
        private EntityRef<SkillS> ownerSkillS;
        public SkillS OwnerSkillC { get => this.ownerSkillS; set => this.ownerSkillS = value; }
        public long EndTime;
    }
}