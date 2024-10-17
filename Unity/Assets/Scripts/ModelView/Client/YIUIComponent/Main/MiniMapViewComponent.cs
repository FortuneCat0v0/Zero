using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public partial class MiniMapViewComponent : Entity
    {
        public GameObject MapCamera;

        public Dictionary<long, GameObject> UIMapMarkers = new();
        public List<GameObject> UIMapMarkerPool = new();

        public float ScaleRateX;
        public float ScaleRateY;
        public long MiniMapTimer;
    }
}