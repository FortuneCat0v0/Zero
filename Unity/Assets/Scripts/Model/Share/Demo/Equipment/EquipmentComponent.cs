using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [ComponentOf]
    public class EquipmentComponent : Entity, IAwake, ITransfer, IUnitCache
    {
        /// <summary>
        /// 位置-装备Id
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> EquipItemsDict = new();
    }
}

