using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class FlyTipComponent: Entity, IAwake, IDestroy
    {
        public List<GameObject> FlyTips = new();
        public List<GameObject> FlyTipDis = new();
    }
}