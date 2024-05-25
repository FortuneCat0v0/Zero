using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SkillIndicatorComponent : Entity, IAwake
    {
        public SkillConfig SkillConfig;
        public Vector2 Vector2;

        public GameObject GameObject;
        public GameObject IndicatorGameObject;

        public Camera MainCamera;
    }
}