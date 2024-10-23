using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UIHeadInfoComponent : Entity, IAwake<Transform>, IDestroy, ILateUpdate
    {
        public Transform TargetTransform;
        public Transform Transform;
        public Image HealthBarFillImg;

        public Camera MainCamera;
    }
}