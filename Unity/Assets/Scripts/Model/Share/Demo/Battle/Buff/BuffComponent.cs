using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class BuffComponent : Entity, IAwake, IDeserialize, ITransfer, IDestroy
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, Buff> BuffDict { get; set; } = new();
    }
}