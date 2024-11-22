using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ClientSkillComponent : Entity, IAwake, IDestroy
    {
        public Unit Unit => this.GetParent<Unit>();

        public Dictionary<int, EntityRef<ClientSkill>> SkillDict { get; set; } = new();

        /// <summary>
        /// 容器SlotId-技能ConfigId
        /// </summary>
        public Dictionary<int, int> SkillSlotDict { get; set; } = new();
    }
}