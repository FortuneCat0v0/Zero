using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class SlimeComponent : Entity, IAwake, IDestroy, IDeserialize, IUnitCache
    {
        [BsonIgnore]
        public Dictionary<long, EntityRef<Slime>> Slimes = new();
    }
}