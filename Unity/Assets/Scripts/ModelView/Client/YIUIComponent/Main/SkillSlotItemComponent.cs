using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public partial class SkillSlotItemComponent : Entity, IUpdate
    {
        public ESkillSlotType SkillSlotType;
        private EntityRef<SkillC> skillC;
        public SkillC SkillC { get => this.skillC; set => this.skillC = value; }
        private EntityRef<SkillIndicatorComponent> skillIndicatorComponent;
        public SkillIndicatorComponent SkillIndicatorComponent { get => this.skillIndicatorComponent; set => this.skillIndicatorComponent = value; }
    }
}