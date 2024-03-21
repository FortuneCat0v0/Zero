using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class EquipmentComponent : Entity, IAwake, ITransfer, IUnitCache
    {
        /// <summary>
        /// 位置-装备Id
        /// </summary>
        public Dictionary<int, long> EquipItemsDict = new();
    }
}

