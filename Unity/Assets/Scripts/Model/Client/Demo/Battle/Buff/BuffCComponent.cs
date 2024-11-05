using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class BuffCComponent : Entity, IAwake, IDestroy
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, BuffC> BuffDict { get; set; } = new();
    }
}