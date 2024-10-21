using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach (ESkillSlotType skillSlotType in Enum.GetValues(typeof(ESkillSlotType)))
            {
                if (!self.SkillSlotDict.ContainsKey((int)skillSlotType))
                {
                    self.SkillSlotDict.Add((int)skillSlotType, 0);
                }
            }
        }

        [EntitySystem]
        private static void Destroy(this SkillComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this SkillComponent self)
        {
        }

        public static void AddSkill(this SkillComponent self, Skill skill)
        {
            if (self.SkillDict.TryAdd(skill.SkillConfigId, skill))
            {
                self.AddChild(skill);
                return;
            }

            Log.Error($"客户端添加技能失败 SkillConfigId : {skill.SkillConfigId}");
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

        public static Skill GetSkillByConfigId(this SkillComponent self, int configId)
        {
            Skill skill = null;
            if (self.SkillDict.TryGetValue(configId, out EntityRef<Skill> value))
            {
                skill = value;
            }

            return skill;
        }

        public static Skill GetSkillByGrid(this SkillComponent self, ESkillSlotType skillSlotType)
        {
            if (self.SkillSlotDict[(int)skillSlotType] == 0)
            {
                return null;
            }

            return self.GetSkillByConfigId(self.SkillSlotDict[(int)skillSlotType]);
        }

        public static List<EntityRef<Skill>> GetAllSkill(this SkillComponent self)
        {
            return self.SkillDict.Values.ToList();
        }

        /// <summary>
        /// 此方法只能由服务端下发的消息调用
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillConfigId"></param>
        /// <param name="angle"></param>
        /// <param name="position"></param>
        /// <param name="targetUnitId"></param>
        public static void SpellSkill(this SkillComponent self, int skillConfigId, long targetUnitId, float angle, float3 position)
        {
            Log.Debug($"释放技能 {skillConfigId}");

            Skill skill = self.GetSkillByConfigId(skillConfigId);

            if (skill == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            skill.StartSpell(targetUnitId, angle, position);
        }

        public static void TrySpellSkill(this SkillComponent self, ESkillSlotType skillSlotType, long targetUnitId, float angle, float distance)
        {
            Log.Debug($"尝试释放技能 ESkillGridType : {skillSlotType}");

            Skill skill = self.GetSkillByGrid(skillSlotType);

            if (skill == null)
            {
                Log.Error($"技能不存在 ESkillGridType : {skillSlotType}");
                return;
            }

            if (!skill.CanSpell())
            {
                return;
            }

            C2M_SpellSkill c2MSpellSkill = C2M_SpellSkill.Create();
            c2MSpellSkill.SkillConfigId = skill.SkillConfigId;
            c2MSpellSkill.TargetUnitId = targetUnitId;
            c2MSpellSkill.Angle = angle;
            c2MSpellSkill.Distance = distance;
            self.Root().GetComponent<ClientSenderComponent>().Send(c2MSpellSkill);
        }
    }
}