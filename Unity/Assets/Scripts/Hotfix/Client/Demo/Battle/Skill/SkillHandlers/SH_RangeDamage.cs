namespace ET.Client
{
    public class SH_RangeDamage : SkillCHandler
    {
        public override void OnInit(SkillC skillS)
        {
        }

        public override void OnUpdate(SkillC skillS)
        {
            Unit owner = skillS.OwnerUnit;

            EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
            {
                Unit = owner,
                EffectId = IdGenerater.Instance.GenerateId(),
                EffectData = new EffectData()
                {
                    EffectConfigId = skillS.SkillConfig.EffectConfigId,
                    Position = skillS.Position,
                    Angle = skillS.Angle
                }
            });

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillC skillS)
        {
        }
    }
}