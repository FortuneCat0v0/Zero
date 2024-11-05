using MongoDB.Bson.Serialization.Attributes;
using Unity.Mathematics;

namespace ET.Client
{
    [ChildOf]
    public class SkillC : Entity, IAwake, IDestroy
    {
        public int SkillConfigId { get; set; }

        public long SpellStartTime { get; set; }

        public long SpellEndTime { get; set; }

        public int CD { get; set; }

        public ESkillState SkillState { get; set; }

        public long TargetUnitId { get; set; }

        public float Angle { get; set; }

        public float3 Position { get; set; }

        public long Timer;

        public Unit OwnerUnit => this.GetParent<SkillCComponent>().GetParent<Unit>();

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

        private SkillConfig skillConfig;

        public SkillCHandler SkillCHandler;

        public long EffectId;
    }
}