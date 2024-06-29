using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class HitResultTipComponent : Entity, IAwake, IDestroy
    {
        public List<GameObject> HitResultTips = new();
    }
}