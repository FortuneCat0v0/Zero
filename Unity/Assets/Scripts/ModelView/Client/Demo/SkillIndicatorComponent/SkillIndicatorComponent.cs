using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake
    {
        public SkillConfig SkillConfig;
        public Vector2 Vector2;
        public float Angle;

        public GameObject GameObject;
        public GameObject Arrow;
        public GameObject ArrowIndicator;
        

        public Camera MainCamera;
    }
}