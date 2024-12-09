namespace ET.Client
{
    public class Skill_RangeDamage : ClientSkillHandler
    {
        public override void OnInit(ClientSkill clientSkillS)
        {
            clientSkillS.Active = false;
        }

        public override void OnUpdate(ClientSkill clientSkillS)
        {
            if (clientSkillS.Active == false)
            {
                Unit owner = clientSkillS.OwnerUnit;

                EventSystem.Instance.Publish(owner.Scene(), new PlayEffect()
                {
                    Unit = owner,
                    EffectId = IdGenerater.Instance.GenerateId(),
                    EffectData = new EffectData()
                    {
                        EffectConfigId = clientSkillS.SkillConfig.EffectConfigId,
                        Position = clientSkillS.Position,
                        Angle = clientSkillS.Angle
                    }
                });

                clientSkillS.Active = true;
                return;
            }

            long nowTime = TimeInfo.Instance.ServerNow();
            if (nowTime < clientSkillS.SpellStartTime + 500)
            {
                return;
            }

            clientSkillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(ClientSkill clientSkillS)
        {
            clientSkillS.Active = false;
        }
    }
}