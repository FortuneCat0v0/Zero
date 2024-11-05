using System;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(SkillS))]
    [FriendOf(typeof(SkillS))]
    public static partial class SkillSSystem
    {
        [Invoke(TimerInvokeType.SkillTimer_Server)]
        public class SkillTimer : ATimer<SkillS>
        {
            protected override void Run(SkillS self)
            {
                self.Update();
            }
        }

        [EntitySystem]
        private static void Awake(this SkillS self, int skillConfigId)
        {
            self.SkillConfigId = skillConfigId;
            self.SetCD();
        }

        [EntitySystem]
        private static void Destroy(this SkillS self)
        {
            self.EndSpell();
        }

        private static void Update(this SkillS self)
        {
            if (self.SkillState == ESkillState.Finished)
            {
                self.EndSpell();
                return;
            }

            self.SkillSHandler.OnUpdate(self);
        }

        public static void EndSpell(this SkillS self)
        {
            if (self.SkillSHandler != null)
            {
                self.SkillSHandler.OnFinish(self);
            }

            self.SkillSHandler = default;

            self.SkillState = ESkillState.Waiting;

            self.TargetUnitId = default;
            self.Position = default;
            self.Angle = default;

            self.SpellEndTime = TimeInfo.Instance.ServerNow();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void StartSpell(this SkillS self, long targetUnitId, float3 position, float angle)
        {
            self.SkillState = ESkillState.Running;

            self.TargetUnitId = targetUnitId;
            self.Position = position;
            self.Angle = angle;

            self.SkillSHandler = SkillSHandlerDispatcherComponent.Instance.Get(self.SkillConfig.SkillHandler);
            self.SkillSHandler.OnInit(self);

            self.SpellStartTime = TimeInfo.Instance.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.SkillTimer_Server, self);
        }

        public static bool CanSpell(this SkillS self)
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

        public static long GetCurrentCD(this SkillS self)
        {
            if (self.SkillState != ESkillState.Waiting)
            {
                return -1;
            }

            return self.SpellEndTime + self.CD - TimeInfo.Instance.ServerNow();
        }

        public static void SetCD(this SkillS self)
        {
            // 这里可以加上减CD属性
            self.CD = self.SkillConfig.CD;
        }

        public static SkillInfo ToMessage(this SkillS self)
        {
            SkillInfo skillInfo = SkillInfo.Create();
            skillInfo.Id = self.Id;
            skillInfo.SkillConfigId = self.SkillConfigId;
            skillInfo.SpellStartTime = self.SpellStartTime;
            skillInfo.SpellEndTime = self.SpellEndTime;
            skillInfo.CD = self.CD;

            return skillInfo;
        }
    }
}