using System;

namespace ET.Server
{
    [FriendOf(typeof (PlayerOfflineOutTimeComponent))]
    [EntitySystemOf(typeof (PlayerOfflineOutTimeComponent))]
    public static partial class PlayerOfflineOutTimeComponentSystem
    {
        [Invoke(TimerInvokeType.PlayerOfflineOutTime)]
        public class PlayerOfflineOutTime: ATimer<PlayerOfflineOutTimeComponent>
        {
            protected override void Run(PlayerOfflineOutTimeComponent self)
            {
                try
                {
                    self.KickPlayer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this PlayerOfflineOutTimeComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeInfo.Instance.ServerNow() + 10000, TimerInvokeType.PlayerOfflineOutTime, self);
        }

        [EntitySystem]
        private static void Destroy(this PlayerOfflineOutTimeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
        {
            DisconnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
        }
    }
}