using UnityEngine;

namespace ET.Client
{
    public class TriggerColliderComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
    }
}