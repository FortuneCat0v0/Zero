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
            UnitFactory.CreateBullet(root,
                new(belongToUnit: owner,
                    colliderConfigId: 1001,
                    targetPos: owner.Position,
                    angle: skillS.Angle,
                    skillS: skillS,
                    collisionHandler: nameof(CH_SimpleArea),
                    paramsList: new() { skillS.SkillConfig.Damage }));

            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillS skillS)
        {
        }
    }
}