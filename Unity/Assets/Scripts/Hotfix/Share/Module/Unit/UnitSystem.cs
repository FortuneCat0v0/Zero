namespace ET
{
    [EntitySystemOf(typeof(Unit))]
    public static partial class UnitSystem
    {
        [EntitySystem]
        private static void Awake(this Unit self, EUnitType unitType, int configId)
        {
            self.UnitType = unitType;
            self.ConfigId = configId;
        }
    }
}