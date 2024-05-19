using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(SkillComponent))]
    [FriendOf(typeof(SkillComponent))]
    public static partial class SkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillComponent self)
        {
            self.IdSkillMap.Clear();
            self.AbstractTypeSkills.Clear();
        }

        public static bool AddSkill(this SkillComponent self, int configId, int skillLevel = 1)
        {
            if (!self.IdSkillMap.ContainsKey(configId))
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(configId, skillLevel);
                if (skillConfig == null)
                {
                    Log.Debug($"配置表不存在技能 {configId} {skillLevel}");
                    return false;
                }

                Skill skill = self.AddChild<Skill, int, int>(configId, skillLevel);
                self.IdSkillMap.Add(configId, skill.Id);
                ESkillAbstractType abstractType = skillConfig.SkillAbstractType;
                if (!self.AbstractTypeSkills.TryGetValue(abstractType, out List<long> skills))
                {
                    skills = new List<long>();
                    self.AbstractTypeSkills[abstractType] = skills;
                }

                self.AbstractTypeSkills[abstractType].Add(skill.Id);

                return true;
            }

            Log.Debug($"已经存在技能 {configId}");
            return false;
        }

        public static Skill GetSkill(this SkillComponent self, int configId)
        {
            Skill skill = null;
            if (self.IdSkillMap.ContainsKey(configId))
            {
                skill = self.GetChild<Skill>(self.IdSkillMap[configId]);
            }

            return skill;
        }

        public static List<Skill> GetAllSkill(this SkillComponent self)
        {
            List<Skill> skills = new List<Skill>();
            foreach (Entity entity in self.Children.Values)
            {
                skills.Add(entity as Skill);
            }

            return skills;
        }

        // public static bool TryGetSkill(this SkillComponent self, ESkillAbstractType abstractType, int index, out Skill skill)
        // {
        //     if (self.AbstractTypeSkills.TryGetValue(abstractType, out List<long> skillIds))
        //     {
        //         if (skillIds?.Count > index)
        //         {
        //             skill = self.GetChild<Skill>(skillIds[index]);
        //             return true;
        //         }
        //     }
        //
        //     skill = null;
        //     return false;
        // }
        //
        // public static bool SpellSkill(this SkillComponent self, ESkillAbstractType absType, int index = 0)
        // {
        //     Log.Info($"spell skill {index}");
        //     Skill skill = null;
        //     self.TryGetSkill(absType, index, out skill);
        //     if (skill == null || skill.IsInCd())
        //         return false;
        //     skill.StartSpell();
        //     return true;
        // }

        public static bool IsDead(this SkillComponent self)
        {
            return self.Unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) <= 0;
        }

        public static void SpellSkill(this SkillComponent self, int skillConfigId, float3 direction, float3 position, long targetUnitId)
        {
            Log.Debug($"尝试释放技能 {skillConfigId}");

            Skill skill = self.GetSkill(skillConfigId);

            if (skill == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            if (skill.IsInCd())
            {
                Log.Debug($"技能在CD中 {skillConfigId}");
                return;
            }

            // 这里可以做一些校验

            skill.StartSpell();

            M2C_SpellSkill m2CSpellSkill = M2C_SpellSkill.Create();
            m2CSpellSkill.UnitId = self.Unit.Id;
            m2CSpellSkill.SkillConfigId = skillConfigId;
            m2CSpellSkill.Direction = direction;
            m2CSpellSkill.Position = position;
            m2CSpellSkill.TargetUnitId = targetUnitId;

            MapMessageHelper.Broadcast(self.Unit, m2CSpellSkill);
        }
    }
}