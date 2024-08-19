using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(SyncPosComponent))]
    [EntitySystemOf(typeof(SyncPosComponent))]
    public static partial class SyncPosComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SyncPosComponent self, Transform transform1, Transform transform2)
        {
            self.Transform1 = transform1;
            self.Transform2 = transform2;
        }

        [EntitySystem]
        private static void LateUpdate(this SyncPosComponent self)
        {
            if (self.Transform1 != null && self.Transform2 != null)
            {
                self.Transform1.position = self.Transform2.position;
            }
        }
    }
}