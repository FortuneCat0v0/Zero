using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class CollisionViewComponent : Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
    }
}