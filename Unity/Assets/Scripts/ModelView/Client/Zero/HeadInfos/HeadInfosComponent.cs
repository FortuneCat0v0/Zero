using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class HeadInfosComponent : Entity, IAwake, ILateUpdate
    {
        public Transform Transform;
        public GameObject Slider_HealthBar_Miniboss;

        public Transform MainCameraTransform;
    }
}