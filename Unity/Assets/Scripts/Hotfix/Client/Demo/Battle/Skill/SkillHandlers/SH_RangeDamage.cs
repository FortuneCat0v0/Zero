namespace ET.Client
{
    public class SH_RangeDamage : SkillCHandler
    {
        public override void OnInit(SkillC skillS)
        {
            skillS.Active = false;
        }

        public override void OnUpdate(SkillC skillS)
        {
            if (skillS.Active == false)
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

                skillS.Active = true;
                return;
            }

            long nowTime = TimeInfo.Instance.ServerNow();
            if (nowTime < skillS.SpellStartTime + 500)
            {
                return;
            }

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillC skillS)
        {
            skillS.Active = false;
        }
    }
}