using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [FriendOf(typeof(Skill))]
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

        public static void AddSkill(this SkillComponent self, Skill skill)
        {
            if (!self.IdSkillMap.ContainsKey(skill.SkillConfigId))
            {
                self.AddChild(skill);
                self.IdSkillMap.Add(skill.SkillConfigId, skill.Id);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skill.SkillConfigId, skill.SkillLevel);
                ESkillAbstractType abstractType = (ESkillAbstractType)skillConfig.AbstractType;
                if (!self.AbstractTypeSkills.TryGetValue(abstractType, out List<long> skills))
                {
                    skills = new List<long>();
                    self.AbstractTypeSkills[abstractType] = skills;
                }

                self.AbstractTypeSkills[abstractType].Add(skill.Id);
            }
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

        /// <summary>
        /// 此方法只能由服务端下发的消息调用
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillConfigId"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="targetUnitId"></param>
        public static void SpllSkill(this SkillComponent self, int skillConfigId, float3 direction, float3 position, long targetUnitId)
        {
            Log.Debug($"释放技能 {skillConfigId}");

            Skill skill = self.GetSkill(skillConfigId);

            if (skill == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            skill.StartSpell();
        }

        public static void TrySpellSkill(this SkillComponent self, int skillConfigId, float3 direction, float3 position, long targetUnitId)
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
                EventSystem.Instance.Publish(self.Root(), new ShowFlyTip() { Str = "技能在CD中..." });
                return;
            }

            // 这里可以做一些校验

            C2M_SpellSkill c2MSpellSkill = C2M_SpellSkill.Create();
            c2MSpellSkill.SkillConfigId = skillConfigId;
            c2MSpellSkill.Direction = direction;
            c2MSpellSkill.Position = position;
            c2MSpellSkill.TargetUnitId = targetUnitId;
            self.Root().GetComponent<ClientSenderComponent>().Send(C2M_SpellSkill.Create());
        }
    }
}