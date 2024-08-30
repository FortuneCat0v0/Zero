using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake
    {
        public SkillConfig SkillConfig;
        public Vector2 Vector2;
        public float Angle;
        public float Distance;
        public float DistanceFactor = 0.05f;

        public GameObject GameObject;

        public Camera MainCamera;
    }
}