using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UnitViewSyncComponent))]
    [EntitySystemOf(typeof(UnitViewSyncComponent))]
    public static partial class UnitViewSyncComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UnitViewSyncComponent self, GameObject go)
        {
            self.GameObject = go;
            self.Transform = go.transform;
            self.Unit = self.GetParent<Unit>();
        }

        [EntitySystem]
        private static void Update(this UnitViewSyncComponent self)
        {
            Unit unit = self.Unit;
            Vector3 unitPos = unit.Position;
            Quaternion unitRot = unit.Rotation;

            if (unitPos != self.TargetPosition || unitRot != self.TargetRotation)
            {
                self.T = 0;
                self.StartPosition = self.Transform.position;
                self.StartRotation = self.Transform.rotation;
                self.TargetPosition = unitPos;
                self.TargetRotation = unit.Rotation;
            }

            self.T += Time.deltaTime;
            self.Transform.position = Vector3.Lerp(self.StartPosition, self.TargetPosition, self.T / DefineCore.FixedDeltaTime);
            self.Transform.rotation = Quaternion.Lerp(self.StartRotation, self.TargetRotation, self.T / DefineCore.FixedDeltaTime);
        }
    }
}