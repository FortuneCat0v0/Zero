using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(KnapsackComponent))]
    public class KnapsackContainerComponent : Entity, IAwake<int>, IDestroy, IDeserialize, ISerializeToEntity
    {
        public int KnapsackContainerType { get; set; }

        [BsonIgnore]
        public Dictionary<long, EntityRef<Item>> Items = new();
    }
}