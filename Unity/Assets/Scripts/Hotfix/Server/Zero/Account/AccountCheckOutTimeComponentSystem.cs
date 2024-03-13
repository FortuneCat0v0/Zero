using System;

namespace ET.Server
{
    [FriendOf(typeof(AccountSessionComponent))]
    [FriendOf(typeof(AccountCheckOutTimeComponent))]
    [EntitySystemOf(typeof(AccountCheckOutTimeComponent))]
    public static partial class AccountCheckOutTimeComponentSystem
    {
        [Invoke(TimerInvokeType.AccountSessionCheckOutTime)]
        public class AccountSessionCheckOutTime : ATimer<AccountCheckOutTimeComponent>
        {
            protected override void Run(AccountCheckOutTimeComponent self)
            {
                try
                {
                    self.DeleteSession();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this AccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeInfo.Instance.ServerNow() + 600000, TimerInvokeType.AccountSessionCheckOutTime, self);
        }

        [EntitySystem]
        private static void Destroy(this AccountCheckOutTimeComponent self)
        {
            self.AccountId = 0;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();

            long sessionId = session.Root().GetComponent<AccountSessionComponent>().Get(self.AccountId);
            if (session.Id == sessionId)
            {
                session.Root().GetComponent<AccountSessionComponent>().Remove(self.AccountId);
            }

            A2C_Disconnect a2CDisconnect = A2C_Disconnect.Create();
            a2CDisconnect.Error = 1;
            session?.Send(a2CDisconnect);
            session?.Disconnect().Coroutine();
        }
    }
}