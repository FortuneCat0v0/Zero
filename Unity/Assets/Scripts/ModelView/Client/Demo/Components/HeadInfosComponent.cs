using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class HeadInfosComponent : Entity, IAwake<Transform>, IDestroy, ILateUpdate
    {
        public Transform Transform { get; set; }
        public Image HealthBarFillImg;

        public Transform MainCameraTransform;
    }
}