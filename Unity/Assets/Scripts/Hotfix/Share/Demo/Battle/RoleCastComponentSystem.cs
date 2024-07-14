namespace ET
{
    [FriendOf(typeof(RoleCastComponent))]
    [EntitySystemOf(typeof(RoleCastComponent))]
    public static partial class RoleCastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RoleCastComponent self, ERoleCamp a, ERoleTag b)
        {
            self.RoleCamp = a;
            self.RoleTag = b;
        }

        public static ERoleCast GetRoleCastToTarget(this RoleCastComponent self, Unit unit)
        {
            if (unit.GetComponent<RoleCastComponent>() == null)
            {
                return ERoleCast.Friendly;
            }

            ERoleCamp roleCamp = unit.GetComponent<RoleCastComponent>().RoleCamp;

            if (roleCamp == self.RoleCamp)
            {
                return ERoleCast.Friendly;
            }

            if (roleCamp != self.RoleCamp)
            {
                if (roleCamp == ERoleCamp.JunHeng || self.RoleCamp == ERoleCamp.JunHeng)
                {
                    return ERoleCast.Neutral;
                }
                else
                {
                    return ERoleCast.Adverse;
                }
            }

            return ERoleCast.Friendly;
        }
    }
}