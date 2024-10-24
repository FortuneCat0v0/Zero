﻿using System;
using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof(Skill))]
    [FriendOf(typeof(Skill))]
    public static partial class SkillSystem
    {
        [Invoke(TimerInvokeType.SkillTimer_Client)]
        public class SkillUpdate : ATimer<Skill>
        {
            protected override void Run(Skill self)
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
        private static void Awake(this Skill self)
        {
        }

        [EntitySystem]
        private static void Awake(this Skill self, int skillId)
        {
        }

        [EntitySystem]
        private static void Destroy(this Skill self)
        {
            self.EndSpell();
        }

        private static void Update(this Skill self)
        {
            long nowTime = TimeInfo.Instance.ServerNow();
            if (nowTime > self.SpellStartTime + self.SkillConfig.Life)
            {
                self.EndSpell();
                return;
            }

            if (self.SkillConfig.AEsClient.Count == 0)
            {
                return;
            }

            if (self.CurrentActionEventIndex == self.SkillConfig.AEsClient.Count - 1)
            {
                return;
            }

            int triggerTime = self.SkillConfig.AETriggerPercentClient[self.CurrentActionEventIndex + 1] / 100 * self.SkillConfig.Life;
            if (nowTime < self.SpellStartTime + triggerTime)
            {
                return;
            }

            self.CurrentActionEventIndex++;

            if (self.CancellationToken == null)
            {
                ETCancellationToken cancellationToken = new();
                self.CancellationToken = cancellationToken;
            }

            ActionEventDispatcherComponent.Instance.HandleExecute(self, self.SkillConfig.AEsClient[self.CurrentActionEventIndex],
                self.SkillConfig.AEParamsClient[self.CurrentActionEventIndex], self.CancellationToken);
        }

        public static void EndSpell(this Skill self)
        {
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.SkillState = ESkillState.Normal;

            self.TargetUnitId = 0;
            self.Position = default;
            self.Angle = default;
            self.EffectId = 0;

            self.SpellEndTime = TimeInfo.Instance.ServerNow();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void StartSpell(this Skill self, long targetUnitId, float angle, float3 position)
        {
            self.SkillState = ESkillState.Execute;
            self.CurrentActionEventIndex = -1;

            self.TargetUnitId = targetUnitId;
            self.Angle = angle;
            self.Position = position;

            self.SpellStartTime = TimeInfo.Instance.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.SkillTimer_Client, self);
        }

        public static bool CanSpell(this Skill self)
        {
            if (self.SkillState == ESkillState.Execute)
            {
                return false;
            }

            if (self.GetCurrentCD() > 0)
            {
                return false;
            }

            return true;
        }

        public static long GetCurrentCD(this Skill self)
        {
            return self.SpellEndTime + self.GetCD() - TimeInfo.Instance.ServerNow();
        }

        public static long GetCD(this Skill self)
        {
            // 这里可以加上减CD属性
            return self.SkillConfig.CD;
        }

        public static void FromMessage(this Skill self, SkillInfo skillInfo)
        {
            self.SkillConfigId = skillInfo.SkillConfigId;
            self.SpellStartTime = skillInfo.SpellStartTime;
            self.SpellEndTime = skillInfo.SpellEndTime;
        }
    }
}