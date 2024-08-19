using System;

namespace ET.Server
{
    [FriendOf(typeof(CancellationComponent))]
    [EntitySystemOf(typeof(CancellationComponent))]
    public static partial class CancellationComponentSystem
    {
        [Invoke(TimerInvokeType.CancellationTimer)]
        public class CancellationTimer : ATimer<CancellationComponent>
        {
            protected override void Run(CancellationComponent self)
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
        private static void Awake(this CancellationComponent self, ETCancellationToken cancellationToken)
        {
            self.CancellationToken = cancellationToken;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.CancellationTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this CancellationComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }
    }
}