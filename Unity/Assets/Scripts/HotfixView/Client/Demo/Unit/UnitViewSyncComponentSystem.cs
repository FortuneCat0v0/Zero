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

            if (unitPos != self.Position)
            {
                self.t = 0;
                self.Position = unitPos;
                self.Rotation = unit.Rotation;
            }

            self.t += Time.deltaTime;
            self.Transform.rotation = Quaternion.Lerp(self.Transform.rotation, self.Rotation, self.t / DefineCore.FixedDeltaTime);
            self.Transform.position = Vector3.Lerp(self.Transform.position, self.Position, self.t / DefineCore.FixedDeltaTime);
        }
    }
}