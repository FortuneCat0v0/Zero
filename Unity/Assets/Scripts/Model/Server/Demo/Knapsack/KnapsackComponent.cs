using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class KnapsackComponent : Entity, IAwake, IDestroy, IDeserialize, IUnitCache
    {
        [BsonIgnore]
        public Dictionary<int, EntityRef<KnapsackContainerComponent>> ContainerInfoDic = new();
    }
}