using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Client
{
    [FriendOf(typeof(ClientSkill))]
    [EntitySystemOf(typeof(ClientSkillComponent))]
    [FriendOf(typeof(ClientSkillComponent))]
    public static partial class SkillCComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSkillComponent self)
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
        private static void Destroy(this ClientSkillComponent self)
        {
        }

        public static void AddSkill(this ClientSkillComponent self, ClientSkill clientSkill)
        {
            if (self.SkillDict.TryAdd(clientSkill.SkillConfigId, clientSkill))
            {
                self.AddChild(clientSkill);
                return;
            }

            Log.Error($"客户端添加技能失败 SkillConfigId : {clientSkill.SkillConfigId}");
        }

        public static bool RemoveSkill(this ClientSkillComponent self, int skillConfigId)
        {
            if (!self.SkillDict.ContainsKey(skillConfigId))
            {
                return false;
            }

            ClientSkill clientSkill = self.GetSkillByConfigId(skillConfigId);
            self.SkillDict.Remove(skillConfigId);

            foreach (KeyValuePair<int, int> keyValue in self.SkillSlotDict)
            {
                if (keyValue.Value == skillConfigId)
                {
                    self.SkillSlotDict[keyValue.Key] = 0;
                }
            }

            clientSkill.Dispose();
            return false;
        }

        public static ClientSkill GetSkillByConfigId(this ClientSkillComponent self, int configId)
        {
            ClientSkill clientSkill = null;
            if (self.SkillDict.TryGetValue(configId, out EntityRef<ClientSkill> value))
            {
                clientSkill = value;
            }

            return clientSkill;
        }

        public static ClientSkill GetSkillBySlot(this ClientSkillComponent self, ESkillSlotType skillSlotType)
        {
            if (self.SkillSlotDict[(int)skillSlotType] == 0)
            {
                return null;
            }

            return self.GetSkillByConfigId(self.SkillSlotDict[(int)skillSlotType]);
        }

        public static List<EntityRef<ClientSkill>> GetAllSkill(this ClientSkillComponent self)
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
        public static void SpellSkill(this ClientSkillComponent self, int skillConfigId, long targetUnitId, float angle, float3 position)
        {
            Log.Debug($"释放技能 {skillConfigId}");

            ClientSkill clientSkill = self.GetSkillByConfigId(skillConfigId);

            if (clientSkill == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            clientSkill.StartSpell(targetUnitId, angle, position);
        }

        public static void TrySpellSkill(this ClientSkillComponent self, ESkillSlotType skillSlotType, long targetUnitId, float angle, float distance)
        {
            Log.Debug($"尝试释放技能 ESkillGridType : {skillSlotType}");

            ClientSkill clientSkill = self.GetSkillBySlot(skillSlotType);

            if (clientSkill == null)
            {
                Log.Error($"技能不存在 ESkillGridType : {skillSlotType}");
                return;
            }

            if (!clientSkill.CanSpell())
            {
                return;
            }

            C2M_SpellSkill c2MSpellSkill = C2M_SpellSkill.Create();
            c2MSpellSkill.SkillConfigId = clientSkill.SkillConfigId;
            c2MSpellSkill.TargetUnitId = targetUnitId;
            c2MSpellSkill.Angle = angle;
            c2MSpellSkill.Distance = distance;
            self.Root().GetComponent<ClientSenderComponent>().Send(c2MSpellSkill);
        }
    }
}