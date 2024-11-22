using System;
using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof(ClientSkill))]
    [FriendOf(typeof(ClientSkill))]
    public static partial class SkillCSystem
    {
        [Invoke(TimerInvokeType.SkillTimer_Client)]
        public class SkillUpdate : ATimer<ClientSkill>
        {
            protected override void Run(ClientSkill self)
            {
                self.Update();
            }
        }

        [EntitySystem]
        private static void Awake(this ClientSkill self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientSkill self)
        {
            self.EndSpell();
        }

        private static void Update(this ClientSkill self)
        {
            if (self.SkillState == ESkillState.Finished)
            {
                self.EndSpell();
                return;
            }

            self.ClientSkillHandler.OnUpdate(self);
        }

        public static void EndSpell(this ClientSkill self)
        {
            if (self.ClientSkillHandler != null)
            {
                self.ClientSkillHandler.OnFinish(self);
            }

            self.ClientSkillHandler = default;

            self.SkillState = ESkillState.Waiting;

            self.TargetUnitId = 0;
            self.Position = default;
            self.Angle = default;
            self.EffectId = 0;

            self.SpellEndTime = TimeInfo.Instance.ServerNow();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void StartSpell(this ClientSkill self, long targetUnitId, float angle, float3 position)
        {
            self.SkillState = ESkillState.Running;

            self.TargetUnitId = targetUnitId;
            self.Angle = angle;
            self.Position = position;

            self.ClientSkillHandler = ClientSkillHandlerDispatcherComponent.Instance.Get(self.SkillConfig.SkillHandler);
            self.ClientSkillHandler.OnInit(self);

            self.SpellStartTime = TimeInfo.Instance.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.SkillTimer_Client, self);
        }

        public static bool CanSpell(this ClientSkill self)
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

        public static long GetCurrentCD(this ClientSkill self)
        {
            if (self.SkillState != ESkillState.Waiting)
            {
                return -1;
            }

            return self.SpellEndTime + self.CD - TimeInfo.Instance.ServerNow();
        }

        public static void FromMessage(this ClientSkill self, SkillInfo skillInfo)
        {
            self.SkillConfigId = skillInfo.SkillConfigId;
            self.SpellStartTime = skillInfo.SpellStartTime;
            self.SpellEndTime = skillInfo.SpellEndTime;
            self.CD = skillInfo.CD;
        }
    }
}