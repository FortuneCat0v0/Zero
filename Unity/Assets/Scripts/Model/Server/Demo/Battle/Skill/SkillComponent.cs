using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy, IDeserialize, IUnitCache
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, EntityRef<Skill>> SkillDict { get; set; } = new();

        /// <summary>
        /// 容器SlotId-技能ConfigId
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, int> SkillSlotDict { get; set; } = new();
    }
}