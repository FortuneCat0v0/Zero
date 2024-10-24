namespace ET.Server
{
    /// <summary>
    /// 一次性的、即时的范围检测
    /// 参数：伤害
    /// </summary>
    public class CH_SimpleArea : CollisionHandler
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
                                int damage = aColliderComponent.Params[0];
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