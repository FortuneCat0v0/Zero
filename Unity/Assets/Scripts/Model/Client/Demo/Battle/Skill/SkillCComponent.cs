using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class SkillCComponent : Entity, IAwake, IDestroy
    {
        public Unit Unit => this.GetParent<Unit>();

        public Dictionary<int, EntityRef<SkillC>> SkillDict { get; set; } = new();

        /// <summary>
        /// 容器SlotId-技能ConfigId
        /// </summary>
        public Dictionary<int, int> SkillSlotDict { get; set; } = new();
    }
}