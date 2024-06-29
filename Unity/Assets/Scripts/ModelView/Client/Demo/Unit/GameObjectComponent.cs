using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent : Entity, IAwake, IDestroy
    {
        public GameObject UnitGo { get; set; }
        public GameObject ModelGo { get; set; }
    }
}