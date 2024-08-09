using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIMainComponent))]
    public class UIMiniMapComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
        public GameObject MapCamera;
        public GameObject RawImage;
        public GameObject UIMapMarker;

        public Dictionary<long, GameObject> UIMapMarkers = new();

        public float ScaleRateX;
        public float ScaleRateY;
        public long MiniMapTimer;
    }
}