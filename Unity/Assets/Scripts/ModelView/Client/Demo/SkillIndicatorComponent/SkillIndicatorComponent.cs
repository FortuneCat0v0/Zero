using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake
    {
        public SkillConfig SkillConfig;
        public GameObject GameObject;
        public Vector2 Vector2;
        public float Angle;

        public Camera MainCamera;
    }
}