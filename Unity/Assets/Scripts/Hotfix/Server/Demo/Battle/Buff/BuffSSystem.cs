using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(BuffS))]
    [FriendOf(typeof(BuffS))]
    [FriendOf(typeof(NumericComponent))]
    public static partial class BuffSSystem
    {
        [Invoke(TimerInvokeType.BuffTimer)]
        public class BuffTimer : ATimer<BuffS>
        {
            protected override void Run(BuffS self)
            {
                try
                {
                    self.Update();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this BuffS self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.BuffTimer, self);
        }

        [EntitySystem]
        private static void Awake(this BuffS self, int BuffId)
        {
            self.BuffConfigId = BuffId;

            self.InitBuff();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.BuffTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this BuffS self)
        {
            if (self.BuffConfig.EndAEs.Count > 0)
            {
                for (int i = 0; i < self.BuffConfig.EndAEs.Count; i++)
                {
                    ActionEventDispatcherComponent.Instance.HandleExecute(self, self.BuffConfig.EndAEs[i], self.BuffConfig.EndAEParams[i]);
                }
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            Log.Warning($"移除buff {self.BuffConfigId}");
        }

        private static void Update(this BuffS self)
        {
            if (TimeInfo.Instance.ServerNow() > self.StartTime + self.BuffConfig.Duration)
            {
                self.LifeTimeout();
                return;
            }

            if (TimeInfo.Instance.ServerNow() > self.NextTriggerTime)
            {
                if (self.BuffConfig.IntervalAEs.Count > 0)
                {
                    for (int i = 0; i < self.BuffConfig.IntervalAEs.Count; i++)
                    {
                        ActionEventDispatcherComponent.Instance.HandleExecute(self, self.BuffConfig.IntervalAEs[i],
                            self.BuffConfig.IntervalAEParams[i]);
                    }
                }

                self.NextTriggerTime = TimeInfo.Instance.ServerNow() + self.BuffConfig.TriggerInterval;
            }
        }

        public static void LifeTimeout(this BuffS self)
        {
            //layerCount > 0时，减少层数量，重新计时buff
            --self.LayerCount;
            if (self.LayerCount > 0)
            {
                self.InitBuff();
                return;
            }

            self.GetParent<BuffSComponent>().RemoveBuff(self.BuffConfigId);
        }

        public static void InitBuff(this BuffS self)
        {
            Log.Warning($"初始化buff {self.BuffConfigId}");

            if (self.BuffConfig.StartAEs.Count > 0)
            {
                for (int i = 0; i < self.BuffConfig.StartAEs.Count; i++)
                {
                    ActionEventDispatcherComponent.Instance.HandleExecute(self, self.BuffConfig.StartAEs[i], self.BuffConfig.StartAEParams[i]);
                }
            }

            self.StartTime = TimeInfo.Instance.ServerNow();
            self.NextTriggerTime = self.StartTime + self.BuffConfig.TriggerInterval;
        }
    }
}