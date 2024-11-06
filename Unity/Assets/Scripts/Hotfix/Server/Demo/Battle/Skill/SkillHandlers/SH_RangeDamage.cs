namespace ET.Server
{
    /// <summary>
    /// 对一个范围内的敌人造成伤害
    /// </summary>
    public class SH_RangeDamage : SkillSHandler
    {
        public override void OnInit(SkillS skillS)
        {
        }

        public override void OnUpdate(SkillS skillS)
        {
            long nowTime = TimeInfo.Instance.ServerNow();
            if (nowTime < skillS.SpellStartTime + 500)
            {
                return;
            }

            Scene root = skillS.Root();
            Unit owner = skillS.OwnerUnit;

            Unit colliderUnit = UnitFactory.CreateColliderUnit(root,
                new(belongToUnit: owner,
                    colliderConfigId: skillS.SkillConfig.ColliderConfigId,
                    followUnitPos: true,
                    followUnitRot: true,
                    skillS: skillS,
                    collisionHandler: nameof(CH_SimpleArea),
                    paramsList: new() { skillS.SkillConfig.Damage })
                , 500);

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillS skillS)
        {
        }
    }
}