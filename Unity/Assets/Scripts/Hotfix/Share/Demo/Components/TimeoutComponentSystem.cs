using System;

namespace ET
{
    [FriendOf(typeof(TimeoutComponent))]
    [EntitySystemOf(typeof(TimeoutComponent))]
    public static partial class ColliderTimeoutComponentSystem
    {
        [Invoke(TimerInvokeType.TimeoutTimer)]
        public class ColliderTimeout : ATimer<TimeoutComponent>
        {
            protected override void Run(TimeoutComponent self)
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
        private static void Awake(this TimeoutComponent self, long time)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(TimeInfo.Instance.ServerNow() + time, TimerInvokeType.TimeoutTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this TimeoutComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }
}