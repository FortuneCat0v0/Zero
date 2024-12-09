namespace ET.Server
{
    public class Skill_Bullet : SkillHandler
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
                    collisionHandler: nameof(Collision_Bullet),
                    paramsList: new() { skill.SkillConfig.Damage }));

            skill.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(Skill skill)
        {
        }
    }

    public class Collision_Bullet : CollisionHandler
    {
        public override void HandleCollisionStart(Unit a, Unit b)
        {
            RoleCastComponent aRole = a.GetComponent<RoleCastComponent>();
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            RoleCastComponent bRole = b.GetComponent<RoleCastComponent>();
            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

            if (aRole == null || bRole == null)
            {
                return;
            }

            ERoleCast roleCast = aRole.GetRoleCastToTarget(b);
            ERoleTag roleTag = bRole.RoleTag;

            switch (roleCast)
            {
                case ERoleCast.Friendly:
                    break;
                case ERoleCast.Adverse:
                    switch (roleTag)
                    {
                        case ERoleTag.Hero:
                            if (!aColliderComponent.UnitIds.Contains(bBelongToUnit.Id))
                            {
                                int damage = aColliderComponent.SkillC.SkillConfig.Damage;
                                BattleHelper.HitSettle(aBelongToUnit, bBelongToUnit, EHitFromType.Skill_Normal, damage);

                                aColliderComponent.UnitIds.Add(bBelongToUnit.Id);
                            }

                            break;
                    }

                    break;
                case ERoleCast.Neutral:
                    break;
            }
        }

        public override void HandleCollisionSustain(Unit a, Unit b)
        {
        }

        public override void HandleCollisionEnd(Unit a, Unit b)
        {
        }
    }
}