using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static partial class UnitComponentSystem
    {
        public static void Add(this UnitComponent self, Unit unit)
        {
        }

        public static Unit Get(this UnitComponent self, long id)
        {
            Unit unit = self.GetChild<Unit>(id);
            return unit;
        }

        public static void Remove(this UnitComponent self, long id)
        {
            Unit unit = self.GetChild<Unit>(id);
            unit?.Dispose();
        }

        public static List<Unit> GetAll(this UnitComponent self)
        {
            List<Unit> units = new List<Unit>();
            foreach (Entity entity in self.Children.Values.ToList())
            {
                units.Add(entity as Unit);
            }

            return units;
        }
    }
}