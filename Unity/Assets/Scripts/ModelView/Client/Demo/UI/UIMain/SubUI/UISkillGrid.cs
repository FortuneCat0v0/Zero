using UnityEngine;

namespace ET.Client
{
    public class UISkillGrid : Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject IconImg;
        public GameObject PrgImg;
        public GameObject TimeText;
        public GameObject ETrigger;

        public SkillConfig SkillConfig;
        public SkillIndicatorComponent SkillIndicatorComponent { get; set; }
    }
}