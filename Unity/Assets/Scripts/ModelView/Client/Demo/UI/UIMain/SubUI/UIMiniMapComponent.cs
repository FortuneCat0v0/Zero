using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIMainComponent))]
    public class UIMiniMapComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
        public GameObject MapCamera;
        public GameObject RawImage;

        public float ScaleRateX;
        public float ScaleRateY;
        public long MiniMapTimer;
    }
}