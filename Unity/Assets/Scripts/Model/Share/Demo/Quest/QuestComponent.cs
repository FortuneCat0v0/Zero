using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf]
    public class QuestComponent : Entity, IAwake
    {
        [BsonIgnore]
        public Dictionary<long, EntityRef<Quest>> QuestsDict = new();
    }
}