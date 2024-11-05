namespace ET.Server
{
    public class SH_Bullet : SkillSHandler
    {
        public override void OnInit(SkillS skillS)
        {
        }

        public override void OnUpdate(SkillS skillS)
        {
            Scene root = skillS.Root();
            Unit owner = skillS.OwnerUnit;
            UnitFactory.CreateBullet(root, new CreateColliderParams()
            {
                BelontToUnit = owner,
                FollowUnitPos = false,
                FollowUnitRot = false,
                Offset = default,
                TargetPos = owner.Position,
                Angle = skillS.Angle,
                ColliderConfigId = 1001,
                SkillS = skillS,
                CollisionHandler = nameof(CH_SimpleArea),
                Params = new() { skillS.SkillConfig.Damage }
            });

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillS skillS)
        {
        }
    }
}