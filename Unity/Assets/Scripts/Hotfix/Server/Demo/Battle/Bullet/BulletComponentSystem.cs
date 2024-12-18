﻿namespace ET.Server
{
    [EntitySystemOf(typeof(BulletComponent))]
    [FriendOf(typeof(BulletComponent))]
    public static partial class BulletComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BulletComponent self)
        {
            self.EndTime = TimeInfo.Instance.ServerNow() + 5000;
        }

        [EntitySystem]
        private static void FixedUpdate(this BulletComponent self)
        {
            if (TimeInfo.Instance.ServerNow() > self.EndTime)
            {
                self.Root().GetComponent<UnitComponent>()?.Remove(self.GetParent<Unit>().Id);
            }
        }

        [EntitySystem]
        private static void Destroy(this BulletComponent self)
        {
        }
    }
}