namespace ET.Server
{
    /// <summary>
    /// 持续进行的范围检测
    /// 参数：间隔时间、伤害
    /// </summary>
    public class CH_ContinuousArea : CollisionHandler
    {
        public override void HandleCollisionStart(Unit a, Unit b)
        {
            RoleCastComponent aRole = a.GetComponent<RoleCastComponent>();
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            RoleCastComponent bRole = b.GetComponent<RoleCastComponent>();
            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

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
                            if (!aColliderComponent.UnitLastTriggerTimeDict.ContainsKey(bBelongToUnit.Id))
                            {
                                int damage = aColliderComponent.Params[1];
                                BattleHelper.HitSettle(aBelongToUnit, bBelongToUnit, EHitFromType.Skill_Normal, damage);

                                aColliderComponent.UnitLastTriggerTimeDict.Add(bBelongToUnit.Id, TimeInfo.Instance.ServerNow());
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
            RoleCastComponent aRole = a.GetComponent<RoleCastComponent>();
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            RoleCastComponent bRole = b.GetComponent<RoleCastComponent>();
            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

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
                            if (aColliderComponent.UnitLastTriggerTimeDict.ContainsKey(bBelongToUnit.Id))
                            {
                                long lastTriggerTime = aColliderComponent.UnitLastTriggerTimeDict[bBelongToUnit.Id];
                                long nowTime = TimeInfo.Instance.ServerNow();
                                if (nowTime - lastTriggerTime > aColliderComponent.Params[0])
                                {
                                    aColliderComponent.UnitLastTriggerTimeDict[bBelongToUnit.Id] = nowTime;
                                    int damage = aColliderComponent.Params[1];
                                    BattleHelper.HitSettle(aBelongToUnit, bBelongToUnit, EHitFromType.Skill_Normal, damage);
                                }
                            }

                            break;
                    }

                    break;
                case ERoleCast.Neutral:
                    break;
            }
        }

        public override void HandleCollisionEnd(Unit a, Unit b)
        {
            RoleCastComponent aRole = a.GetComponent<RoleCastComponent>();
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            RoleCastComponent bRole = b.GetComponent<RoleCastComponent>();
            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

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
                            aColliderComponent.UnitLastTriggerTimeDict.Remove(bBelongToUnit.Id);

                            break;
                    }

                    break;
                case ERoleCast.Neutral:
                    break;
            }
        }
    }
}