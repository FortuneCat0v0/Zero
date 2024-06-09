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
            foreach (ESkillGridType eSkillGridType in Enum.GetValues(typeof(ESkillGridType)))
            {
                if (!self.SkillGridDict.ContainsKey((int)eSkillGridType))
                {
                    self.SkillGridDict.Add((int)eSkillGridType, 0);
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

        public static Skill GetSkillByConfigId(this SkillComponent self, int configId)
        {
            Skill skill = null;
            if (self.SkillDict.TryGetValue(configId, out Skill value))
            {
                skill = value;
            }

            return skill;
        }

        public static Skill GetSkillByGrid(this SkillComponent self, ESkillGridType skillGridType)
        {
            if (self.SkillGridDict[(int)skillGridType] == 0)
            {
                return null;
            }

            return self.GetSkillByConfigId(self.SkillGridDict[(int)skillGridType]);
        }

        public static List<Skill> GetAllSkill(this SkillComponent self)
        {
            return self.SkillDict.Values.ToList();
        }

        /// <summary>
        /// 此方法只能由服务端下发的消息调用
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillConfigId"></param>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        /// <param name="targetUnitId"></param>
        public static void SpllSkill(this SkillComponent self, EInputType inputType, int skillConfigId, float3 direction, float3 position,
        long targetUnitId)
        {
            Log.Debug($"释放技能 {skillConfigId}");

            Skill skill = self.GetSkillByConfigId(skillConfigId);

            if (skill == null)
            {
                Log.Debug($"技能不存在 {skillConfigId}");
                return;
            }

            skill.StartSpell(inputType);
        }

        public static void TrySpellSkill(this SkillComponent self, EInputType inputType, ESkillGridType skillGridType, float3 direction,
        float3 position, long targetUnitId)
        {
            Log.Debug($"尝试释放技能 ESkillGridType : {skillGridType}");

            Skill skill = self.GetSkillByGrid(skillGridType);

            if (skill == null)
            {
                Log.Error($"技能不存在 ESkillGridType : {skillGridType}");
                return;
            }

            if (skill.SkillState == SkillState.Cooldown)
            {
                EventSystem.Instance.Publish(self.Root(), new ShowFlyTip() { Str = "技能在CD中..." });
                return;
            }

            // 这里可以做一些校验

            C2M_Operation c2MOperation = C2M_Operation.Create();
            c2MOperation.OperateType = (int)EOperateType.Skill;
            c2MOperation.InputType = (int)inputType;
            c2MOperation.Value_Int_1 = skill.SkillConfigId;
            c2MOperation.Value_Vec3_1 = direction;
            c2MOperation.Value_Vec3_2 = position;
            c2MOperation.Value_Long_1 = targetUnitId;
            self.Root().GetComponent<ClientSenderComponent>().Send(c2MOperation);
        }
    }
}