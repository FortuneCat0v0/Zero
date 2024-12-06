namespace ET.Server
{
    /// <summary>
    /// 进入某个区域
    /// </summary>
    public class CH_ContactArea : CollisionHandler
    {
        public override void HandleCollisionStart(Unit a, Unit b)
        {
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

            if (aBelongToUnit.UnitType == UnitType.Area && bBelongToUnit.UnitType == UnitType.Player)
            {
                Log.Warning($"玩家 {bBelongToUnit.Id} 进入到 {aBelongToUnit.ConfigId}");

                AreaConfig areaConfig = AreaConfigCategory.Instance.Get(aBelongToUnit.ConfigId);
                if (areaConfig.AreaType == AreaType.Water)
                {
                    Log.Debug($"玩家 {bBelongToUnit.Id} 开始获取水元素");
                }
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