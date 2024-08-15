using System;

namespace ET.Server
{
    [FriendOf(typeof(ColliderTimeoutComponent))]
    [EntitySystemOf(typeof(ColliderTimeoutComponent))]
    public static partial class ColliderTimeoutComponentSystem
    {
        [Invoke(TimerInvokeType.ColliderTimeout)]
        public class ColliderTimeout : ATimer<ColliderTimeoutComponent>
        {
            protected override void Run(ColliderTimeoutComponent self)
            {
                try
                {
                    self.Parent.Dispose();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ColliderTimeoutComponent self, long time)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeInfo.Instance.ServerNow() + time, TimerInvokeType.ColliderTimeout, self);
        }

        [EntitySystem]
        private static void Destroy(this ColliderTimeoutComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }
}