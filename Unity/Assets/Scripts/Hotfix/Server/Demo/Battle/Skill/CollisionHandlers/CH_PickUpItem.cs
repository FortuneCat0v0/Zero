namespace ET.Server
{
    /// <summary>
    /// 捡道具
    /// </summary>
    public class CH_PickUpItem : CollisionHandler
    {
        public override void HandleCollisionStart(Unit a, Unit b)
        {
            ColliderComponent aColliderComponent = a.GetComponent<ColliderComponent>();
            Unit aBelongToUnit = aColliderComponent.BelongToUnit;

            ColliderComponent bColliderComponent = b.GetComponent<ColliderComponent>();
            Unit bBelongToUnit = bColliderComponent.BelongToUnit;

            if (aBelongToUnit.UnitType == EUnitType.Item && bBelongToUnit.UnitType == EUnitType.Player)
            {
                Log.Warning($"玩家 {bBelongToUnit.Id} 拾取到 {aBelongToUnit.ConfigId}");
                aBelongToUnit.GetParent<UnitComponent>().Remove(aBelongToUnit.Id);
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