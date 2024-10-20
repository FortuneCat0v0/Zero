using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class BagComponent : Entity, IAwake, IDeserialize, IUnitCache
    {
        [BsonIgnore]
        public Dictionary<long, EntityRef<Item>> ItemsDict = new();
    }
}