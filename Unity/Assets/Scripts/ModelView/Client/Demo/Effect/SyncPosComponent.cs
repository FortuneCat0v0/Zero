using UnityEngine;

namespace ET.Client
{
    [ComponentOf]
    public class SyncPosComponent : Entity, IAwake<Transform, Transform>, ILateUpdate
    {
        public Transform Transform1;
        public Transform Transform2;
    }
}