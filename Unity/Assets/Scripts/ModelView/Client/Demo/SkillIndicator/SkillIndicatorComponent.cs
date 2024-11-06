using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake
    {
        private EntityRef<Unit> unit;
        public Unit Unit { get => this.unit; set => this.unit = value; }
        public SkillConfig SkillConfig;
        public Vector2 Vector2;
        public float Angle;
        public float Distance;
        public float DistanceFactor = 0.05f;

        public GameObject GameObject;

        public Camera MainCamera;
    }
}