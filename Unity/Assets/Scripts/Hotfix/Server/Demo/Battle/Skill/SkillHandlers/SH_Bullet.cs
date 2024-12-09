namespace ET.Server
{
    public class SH_Bullet : SkillHandler
    {
        public override void OnInit(Skill skill)
        {
        }

        public override void OnUpdate(Skill skill)
        {
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;
            UnitFactory.CreateBullet(root,
                new(belongToUnit: owner,
                    colliderParams: skill.SkillConfig.ColliderParams,
                    targetPos: owner.Position,
                    angle: skill.Angle,
                    skill: skill,
                    collisionHandler: nameof(CH_SimpleArea),
                    paramsList: new() { skill.SkillConfig.Damage }));

            skill.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(Skill skill)
        {
        }
    }
}