using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach (ESkillGridType eSkillGridType in Enum.GetValues(typeof(ESkillGridType)))
            {
                if (!self.SkillGridDict.ContainsKey((int)eSkillGridType))
                {
                    self.SkillGridDict.Add((int)eSkillGridType, 0);
                }
            }

            // 测试
            self.SkillGridDict[0] = 10001;
            self.SkillGridDict[1] = 10002;
        }

        [EntitySystem]
        private static void Destroy(this SkillComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this SkillComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                Skill skill = entity as Skill;
                self.SkillDict.Add(skill.SkillConfigId, skill);
            }
        }

        public static bool AddSkill(this SkillComponent self, int configId, int skillLevel = 1)
        {
            if (!self.SkillDict.ContainsKey(configId))
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(configId, skillLevel);
                if (skillConfig == null)
                {
                    Log.Error($"配置表不存在技能 {configId} {skillLevel}");
                    return false;
                }

                Skill skill = self.AddChild<Skill, int, int>(configId, skillLevel);
                self.SkillDict.Add(configId, skill);

                return true;
            }

            Log.Error($"已经存在技能 configId:{configId} lv:{skillLevel}");
            return false;
        }

        public static Skill GetSkillByConfigId(this SkillComponent self, int configId)
        {
            Skill skill = null;
            if (self.SkillDict.TryGetValue(configId, out Skill value))
            {
                skill = value;
            }

            return skill;
        }

        public static List<Skill> GetAllSkill(this SkillComponent self)
        {
            return self.SkillDict.Values.ToList();
        }

        public static bool SpellSkill(this SkillComponent self, int skillConfigId, long targetUnitId, float3 position, float3 direction)
        {
            Skill skill = self.GetSkillByConfigId(skillConfigId);

            if (skill == null)
            {
                Log.Debug($"Server 技能不存在 {skillConfigId}");
                return false;
            }

            if (!skill.CanSpell())
            {
                return false;
            }

            skill.StartSpell(targetUnitId, position, direction);
            return true;
        }
    }
}