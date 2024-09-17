using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UnitViewSyncComponent : Entity, IAwake<GameObject>, IUpdate
    {
        public GameObject GameObject;
        public Transform Transform;
        public EntityRef<Unit> Unit;
        public Vector3 StartPosition;
        public Quaternion StartRotation;
        public Vector3 TargetPosition;
        public Quaternion TargetRotation;
        public float T;
    }
}