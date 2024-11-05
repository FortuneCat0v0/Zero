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
            if (nowTime < skillS.SpellStartTime + 100)
            {
                return;
            }

            Scene root = skillS.Root();
            Unit owner = skillS.OwnerUnit;

            Unit colliderUnit = UnitFactory.CreateColliderUnit(root,
                new CreateColliderParams()
                {
                    BelontToUnit = owner,
                    FollowUnitPos = true,
                    FollowUnitRot = true,
                    Offset = default,
                    TargetPos = default,
                    Angle = default,
                    ColliderConfigId = skillS.SkillConfig.ColliderConfigId,
                    SkillS = skillS,
                    CollisionHandler = nameof(CH_SimpleArea),
                    Params = new() { skillS.SkillConfig.Damage }
                }, 500);

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillS skillS)
        {
        }
    }
}