﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class UISkillGrid : Entity, IAwake<GameObject>, IUpdate
    {
        public GameObject GameObject;
        public GameObject IconImg;
        public GameObject LevelImgs;
        public Image CDImg;
        public TMP_Text CDText;
        public GameObject ETrigger;

        public ESkillSlotType SkillSlotType;
        public ClientSkill ClientSkill { get; set; }
        public SkillIndicatorComponent SkillIndicatorComponent { get; set; }
    }
}