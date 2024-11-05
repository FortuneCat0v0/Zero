using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BuffSComponent : Entity, IAwake, IDeserialize, ITransfer, IDestroy
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, BuffS> BuffDict { get; set; } = new();
    }
}