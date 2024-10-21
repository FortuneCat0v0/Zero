﻿using System;
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
            foreach (ESkillSlotType eSkillGridType in Enum.GetValues(typeof(ESkillSlotType)))
            {
                if (!self.SkillSlotDict.ContainsKey((int)eSkillGridType))
                {
                    self.SkillSlotDict.Add((int)eSkillGridType, 0);
                }
            }

            // 测试
            self.SkillSlotDict[0] = 10001;
            self.SkillSlotDict[1] = 10011;
            self.SkillSlotDict[2] = 10021;
            self.SkillSlotDict[3] = 10031;
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

        public static bool AddSkill(this SkillComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillConfigId);
                if (skillConfig == null)
                {
                    Log.Error($"配置表不存在技能 {skillConfigId}");
                    return false;
                }

                Skill skill = self.AddChild<Skill, int>(skillConfigId);
                self.SkillDict.Add(skillConfigId, skill);

                return true;
            }

            Log.Error($"已经存在技能 configId:{skillConfigId}");
            return false;
        }

        public static bool RemoveSkill(this SkillComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                return false;
            }

            Skill skill = self.GetSkillByConfigId(skillConfigId);
            self.SkillDict.Remove(skillConfigId);

            foreach (KeyValuePair<int, int> keyValue in self.SkillSlotDict)
            {
                if (keyValue.Value == skillConfigId)
                {
                    self.SkillSlotDict[keyValue.Key] = 0;
                }
            }

            skill.Dispose();
            return false;
        }

        public static bool SetSkillGrid(this SkillComponent self, int skillConfigId, ESkillSlotType skillSlotType)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                return false;
            }

            foreach (KeyValuePair<int, int> keyValue in self.SkillSlotDict)
            {
                if (keyValue.Value == skillConfigId)
                {
                    self.SkillSlotDict[keyValue.Key] = 0;
                }
            }

            self.SkillSlotDict[(int)skillSlotType] = skillConfigId;

            return true;
        }

        public static Skill GetSkillByConfigId(this SkillComponent self, int configId)
        {
            Skill skill = null;
            if (self.SkillDict.TryGetValue(configId, out EntityRef<Skill> value))
            {
                skill = value;
            }

            return skill;
        }

        public static List<EntityRef<Skill>> GetAllSkill(this SkillComponent self)
        {
            return self.SkillDict.Values.ToList();
        }

        public static bool SpellSkill(this SkillComponent self, int skillConfigId, long targetUnitId, float3 position, float angle)
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

            skill.StartSpell(targetUnitId, position, angle);
            return true;
        }
    }
}