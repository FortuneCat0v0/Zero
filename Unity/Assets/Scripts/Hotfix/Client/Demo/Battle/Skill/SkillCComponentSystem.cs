using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    [FriendOf(typeof(SkillC))]
    [EntitySystemOf(typeof(SkillCComponent))]
    [FriendOf(typeof(SkillCComponent))]
    public static partial class SkillCComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillCComponent self)
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
        private static void Destroy(this SkillCComponent self)
        {
        }

        public static void AddSkill(this SkillCComponent self, SkillC skillC)
        {
            if (self.SkillDict.TryAdd(skillC.SkillConfigId, skillC))
            {
                self.AddChild(skillC);
                return;
            }

            Log.Error($"客户端添加技能失败 SkillConfigId : {skillC.SkillConfigId}");
        }

        public static bool RemoveSkill(this SkillCComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                return false;
            }

            SkillC skillC = self.GetSkillByConfigId(skillConfigId);
            self.SkillDict.Remove(skillConfigId);

            foreach (KeyValuePair<int, int> keyValue in self.SkillSlotDict)
            {
                if (keyValue.Value == skillConfigId)
                {
                    self.SkillSlotDict[keyValue.Key] = 0;
                }
            }

            skillC.Dispose();
            return false;
        }

        public static SkillC GetSkillByConfigId(this SkillCComponent self, int configId)
        {
            SkillC skillC = null;
            if (self.SkillDict.TryGetValue(configId, out EntityRef<SkillC> value))
            {
                skillC = value;
            }

            return skillC;
        }

        public static SkillC GetSkillBySlot(this SkillCComponent self, ESkillSlotType skillSlotType)
        {
            if (self.SkillSlotDict[(int)skillSlotType] == 0)
            {
                return null;
            }

            return self.GetSkillByConfigId(self.SkillSlotDict[(int)skillSlotType]);
        }

        public static List<EntityRef<SkillC>> GetAllSkill(this SkillCComponent self)
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
        public static void SpellSkill(this SkillCComponent self, int skillConfigId, long targetUnitId, float angle, float3 position)
        {
            Log.Debug($"释放技能 {skillConfigId}");

            SkillC skillC = self.GetSkillByConfigId(skillConfigId);

            if (skillC == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            skillC.StartSpell(targetUnitId, angle, position);
        }

        public static void TrySpellSkill(this SkillCComponent self, ESkillSlotType skillSlotType, long targetUnitId, float angle, float distance)
        {
            Log.Debug($"尝试释放技能 ESkillGridType : {skillSlotType}");

            SkillC skillC = self.GetSkillBySlot(skillSlotType);

            if (skillC == null)
            {
                Log.Error($"技能不存在 ESkillGridType : {skillSlotType}");
                return;
            }

            if (!skillC.CanSpell())
            {
                return;
            }

            C2M_SpellSkill c2MSpellSkill = C2M_SpellSkill.Create();
            c2MSpellSkill.SkillConfigId = skillC.SkillConfigId;
            c2MSpellSkill.TargetUnitId = targetUnitId;
            c2MSpellSkill.Angle = angle;
            c2MSpellSkill.Distance = distance;
            self.Root().GetComponent<ClientSenderComponent>().Send(c2MSpellSkill);
        }
    }
}