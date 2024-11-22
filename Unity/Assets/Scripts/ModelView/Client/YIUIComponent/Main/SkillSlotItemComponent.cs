using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public partial class SkillSlotItemComponent : Entity, IUpdate
    {
        public ESkillSlotType SkillSlotType;
        private EntityRef<ClientSkill> clientSkill;
        public ClientSkill ClientSkill { get => this.clientSkill; set => this.clientSkill = value; }
        private EntityRef<SkillIndicatorComponent> skillIndicatorComponent;
        public SkillIndicatorComponent SkillIndicatorComponent { get => this.skillIndicatorComponent; set => this.skillIndicatorComponent = value; }
    }
}