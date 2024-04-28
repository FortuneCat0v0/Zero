using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CameraComponent : Entity, IAwake, ILateUpdate
    {
        public Camera Camera;
        public Transform UnitTransform;
    }
}