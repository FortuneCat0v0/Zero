using System;

namespace ET
{
    [EntitySystemOf(typeof(Unit))]
    public static partial class UnitSystem
    {
        [EntitySystem]
        private static void Awake(this Unit self, UnitType unitType, int configId)
        {
            self.UnitType = unitType;
            self.ConfigId = configId;
        }

        [EntitySystem]
        private static void GetComponentSys(this Unit self, Type type)
        {
            if (!typeof(IUnitCache).IsAssignableFrom(type))
            {
                return;
            }

            EventSystem.Instance.Publish(self.Scene(), new UnitGetComponent() { Unit = self, Type = type });
        }
    }
}