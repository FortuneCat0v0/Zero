namespace ET.Server
{
    /// <summary>
    /// 对一个范围内的敌人造成伤害
    /// </summary>
    public class SH_RangeDamage : SkillHandler
    {
        public override void OnInit(Skill skill)
        {
        }

        public override void OnUpdate(Skill skill)
        {
            long nowTime = TimeInfo.Instance.ServerNow();
            if (nowTime < skill.SpellStartTime + 500)
            {
                return;
            }

            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            Unit colliderUnit = UnitFactory.CreateSkill(root,
                new(belongToUnit: owner,
                    colliderConfigId: skill.SkillConfig.ColliderConfigId,
                    followUnitPos: true,
                    followUnitRot: true,
                    skill: skill,
                    collisionHandler: nameof(CH_SimpleArea),
                    paramsList: new() { skill.SkillConfig.Damage })
                , 500);

            skill.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(Skill skill)
        {
        }
    }
}