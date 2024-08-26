using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FlyTipComponent : Entity, IAwake, IDestroy, IUpdate
    {
        public List<GameObject> FlyTips = new();
        public Queue<string> FlyTipQueue = new();
        public long LastSpawnFlyTipTime;

        public long Interval = 400;

        [StaticField]
        public static FlyTipComponent Instance;

        public Transform Panel;
    }
}