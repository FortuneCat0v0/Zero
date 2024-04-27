namespace ET.Client
{
    [EntitySystemOf(typeof(Skill))]
    [FriendOf(typeof(Skill))]
    public static partial class SkillSystem
    {
        [EntitySystem]
        private static void Awake(this Skill self)
        {
        }

        [EntitySystem]
        private static void Awake(this Skill self, int skillId, int skillLevel)
        {
        }

        [EntitySystem]
        private static void Destroy(this Skill self)
        {
        }

        public static Unit GetOwnerUnit(this Skill self)
        {
            return self.GetParent<SkillComponent>().Unit;
        }

        public static bool IsInCd(this Skill self)
        {
            if (self.SpellStartTime + self.CD > TimeInfo.Instance.ServerNow())
                return true;
            return false;
        }

        public static void StartSpell(this Skill self)
        {
            self.SpellStartTime = TimeInfo.Instance.ServerNow();
            self.GetComponent<SkillTimelineComponent>().StartPlay();
        }

        public static void FromMessage(this Skill self, SkillInfo skillInfo)
        {
            self.SkillConfigId = skillInfo.SkillConfigId;
            self.SkillLevel = skillInfo.SkillLevel;
            self.SpellStartTime = skillInfo.SpellStartTime;

            self.CD = self.SkillConfig.CD;
            self.AddComponent<SkillTimelineComponent, int, int>(self.SkillConfigId, self.SkillLevel);
        }
    }
}