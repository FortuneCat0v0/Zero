using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy, IDeserialize, IUnitCache
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, Skill> SkillDict { get; set; } = new();

        /// <summary>
        /// 容器GridId-技能ConfigId
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, int> SkillGridDict { get; set; } = new();
    }
}