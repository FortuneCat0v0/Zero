using System;

namespace ET.Server
{
    [FriendOf(typeof(ColliderCancellationTokenComponent))]
    [EntitySystemOf(typeof(ColliderCancellationTokenComponent))]
    public static partial class ColliderCancellationTokenComponentSystem
    {
        [Invoke(TimerInvokeType.ColliderCancellationToken)]
        public class ColliderCancellationToken : ATimer<ColliderCancellationTokenComponent>
        {
            protected override void Run(ColliderCancellationTokenComponent self)
            {
                try
                {
                    if (self.CancellationToken.IsCancel())
                    {
                        self.Parent.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ColliderCancellationTokenComponent self, ETCancellationToken cancellationToken)
        {
            self.CancellationToken = cancellationToken;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.ColliderCancellationToken, self);
        }

        [EntitySystem]
        private static void Destroy(this ColliderCancellationTokenComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }
}