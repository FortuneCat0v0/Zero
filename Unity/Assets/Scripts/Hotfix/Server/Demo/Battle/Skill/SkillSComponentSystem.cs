using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(SkillSComponent))]
    [FriendOf(typeof(SkillSComponent))]
    public static partial class SkillSComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillSComponent self)
        {
            foreach (ESkillSlotType eSkillGridType in Enum.GetValues(typeof(ESkillSlotType)))
            {
                if (!self.SkillSlotDict.ContainsKey((int)eSkillGridType))
                {
                    self.SkillSlotDict.Add((int)eSkillGridType, 0);
                }
            }
        }

        [EntitySystem]
        private static void Destroy(this SkillSComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this SkillSComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                SkillS skillS = entity as SkillS;
                skillS.SetCD();
                self.SkillDict.Add(skillS.SkillConfigId, skillS);
            }
        }

        public static bool AddSkill(this SkillSComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillConfigId);
                if (skillConfig == null)
                {
                    Log.Error($"配置表不存在技能 {skillConfigId}");
                    return false;
                }

                SkillS skillS = self.AddChild<SkillS, int>(skillConfigId);
                self.SkillDict.Add(skillConfigId, skillS);

                return true;
            }

            Log.Error($"已经存在技能 configId:{skillConfigId}");
            return false;
        }

        public static bool RemoveSkill(this SkillSComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                return false;
            }

            SkillS skillS = self.GetSkillByConfigId(skillConfigId);
            self.SkillDict.Remove(skillConfigId);

            foreach (KeyValuePair<int, int> keyValue in self.SkillSlotDict)
            {
                if (keyValue.Value == skillConfigId)
                {
                    self.SkillSlotDict[keyValue.Key] = 0;
                }
            }

            skillS.Dispose();
            return false;
        }

        public static bool SetSkillSlot(this SkillSComponent self, int skillConfigId, ESkillSlotType skillSlotType)
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

        public static SkillS GetSkillByConfigId(this SkillSComponent self, int configId)
        {
            SkillS skillS = null;
            if (self.SkillDict.TryGetValue(configId, out EntityRef<SkillS> value))
            {
                skillS = value;
            }

            return skillS;
        }

        public static List<EntityRef<SkillS>> GetAllSkill(this SkillSComponent self)
        {
            return self.SkillDict.Values.ToList();
        }

        public static bool SpellSkill(this SkillSComponent self, int skillConfigId, long targetUnitId, float3 position, float angle)
        {
            SkillS skillS = self.GetSkillByConfigId(skillConfigId);

            if (skillS == null)
            {
                Log.Debug($"Server 技能不存在 {skillConfigId}");
                return false;
            }

            if (!skillS.CanSpell())
            {
                return false;
            }

            skillS.StartSpell(targetUnitId, position, angle);
            return true;
        }
    }
}