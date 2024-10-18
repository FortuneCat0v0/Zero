using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public partial class SkillSlotItemComponent : Entity, IUpdate
    {
        public ESkillSlotType SkillSlotType;
        private EntityRef<Skill> skill;
        public Skill Skill { get => this.skill; set => this.skill = value; }
        private EntityRef<SkillIndicatorComponent> skillIndicatorComponent;
        public SkillIndicatorComponent SkillIndicatorComponent { get => this.skillIndicatorComponent; set => this.skillIndicatorComponent = value; }
    }
}