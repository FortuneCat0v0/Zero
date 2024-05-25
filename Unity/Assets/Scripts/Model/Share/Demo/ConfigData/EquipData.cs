using System.Collections.Generic;

namespace ET
{
    public static class EquipData
    {
        [StaticField]
        public static Dictionary<int, List<int>> EquipDict = new()
        {
            { (int)EquipPosition.Head, new List<int>() { (int)EquipmentType.Head } },
            { (int)EquipPosition.Body, new List<int>() { (int)EquipmentType.Clothes } }
        };
    }
}

