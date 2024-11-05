using System;
using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof(SkillC))]
    [FriendOf(typeof(SkillC))]
    public static partial class SkillCSystem
    {
        [Invoke(TimerInvokeType.SkillTimer_Client)]
        public class SkillUpdate : ATimer<SkillC>
        {
            protected override void Run(SkillC self)
            {
                self.Update();
            }
        }

        [EntitySystem]
        private static void Awake(this SkillC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillC self)
        {
            self.EndSpell();
        }

        private static void Update(this SkillC self)
        {
            if (self.SkillState == ESkillState.Finished)
            {
                self.EndSpell();
                return;
            }

            self.SkillCHandler.OnUpdate(self);
        }

        public static void EndSpell(this SkillC self)
        {
            if (self.SkillCHandler != null)
            {
                self.SkillCHandler.OnFinish(self);
            }

            self.SkillCHandler = default;

            self.SkillState = ESkillState.Waiting;

            self.TargetUnitId = 0;
            self.Position = default;
            self.Angle = default;
            self.EffectId = 0;

            self.SpellEndTime = TimeInfo.Instance.ServerNow();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void StartSpell(this SkillC self, long targetUnitId, float angle, float3 position)
        {
            self.SkillState = ESkillState.Running;

            self.TargetUnitId = targetUnitId;
            self.Angle = angle;
            self.Position = position;

            self.SkillCHandler = SkillCHandlerDispatcherComponent.Instance.Get(self.SkillConfig.SkillHandler);
            self.SkillCHandler.OnInit(self);

            self.SpellStartTime = TimeInfo.Instance.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.SkillTimer_Client, self);
        }

        public static bool CanSpell(this SkillC self)
        {
            if (self.SkillState != ESkillState.Waiting)
            {
                return false;
            }

            if (self.GetCurrentCD() > 0)
            {
                return false;
            }

            return true;
        }

        public static long GetCurrentCD(this SkillC self)
        {
            if (self.SkillState != ESkillState.Waiting)
            {
                return -1;
            }

            return self.SpellEndTime + self.CD - TimeInfo.Instance.ServerNow();
        }

        public static void FromMessage(this SkillC self, SkillInfo skillInfo)
        {
            self.SkillConfigId = skillInfo.SkillConfigId;
            self.SpellStartTime = skillInfo.SpellStartTime;
            self.SpellEndTime = skillInfo.SpellEndTime;
            self.CD = skillInfo.CD;
        }
    }
}