using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class HeadInfosComponent : Entity, IAwake, ILateUpdate, IDestroy
    {
        public Transform Transform;
        public Image HealthBarFillImg;

        public Transform MainCameraTransform;
    }
}