using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.NowHp)]
    public class NumericWatcher_AddAttributePoint : INumericWatcher
    {
        public void Run(Unit unit, NumericChange args)
        {
            // if (args.NumericType == NumericType.Power)
            // {
            //     unit.GetComponent<NumericComponent>()[NumericType.DamageValueAdd] += 5;
            // }
            //
            // //体力+1点 最大生命值 +1%
            // if (args.NumericType == NumericType.PhysicalStrength)
            // {
            //     unit.GetComponent<NumericComponent>()[NumericType.MaxHpPct] += 1*10000;
            // }
            //
            // //敏捷+1点  闪避概率加0.1%
            // if (args.NumericType == NumericType.Agile)
            // {
            //     unit.GetComponent<NumericComponent>()[NumericType.DodgeFinalAdd] += 1 * 1000;
            // }
            //
            // //精神+1点 最大法力值 +1%
            // if (args.NumericType == NumericType.Spirit)
            // {
            //     unit.GetComponent<NumericComponent>()[NumericType.MaxMpFinalPct] += 1 * 10000;
            // }
        }
    }

    [Event(SceneType.Map)]
    public class UnitDeath_Notice : AEvent<Scene, UnitDeath>
    {
        protected override async ETTask Run(Scene scene, UnitDeath args)
        {
            if (args.DefendUnit.UnitType == EUnitType.Monster)
            {
                UnitFactory.CreateItem(scene, args.DefendUnit.Position, 1);
            }

            OnRemoveUnit(scene, args.DefendUnit, 1000).Coroutine();
            await ETTask.CompletedTask;
        }

        private async ETTask OnRemoveUnit(Scene scene, Unit unit, long waitTime)
        {
            await scene.GetComponent<TimerComponent>().WaitAsync(waitTime);
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            unit.GetParent<UnitComponent>().Remove(unit.Id);
        }
    }

    public static class BattleHelper
    {
        public static void HitSettle(Unit from, Unit to, EHitFromType hitType, int damage = 0)
        {
            if (to.GetComponent<NumericComponent>().GetAsInt(NumericType.Death) > 0)
            {
                return;
            }

            switch (hitType)
            {
                case EHitFromType.Skill_Normal:
                {
                    int dmg = damage;
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.NowHp) - dmg;
                    to.GetComponent<NumericComponent>().Set(NumericType.NowHp, finalHp);
                    if (finalHp <= 0)
                    {
                        to.GetComponent<NumericComponent>().Set(NumericType.Death, 1);
                        // 死亡发事件通知
                        EventSystem.Instance.Publish(from.Root(), new UnitDeath() { AttackUnit = from, DefendUnit = to });
                    }

                    Log.Info($"hit settle, from:{from?.Id}, to:{to?.Id}, value:{dmg}");

                    EventSystem.Instance.Publish(from.Root(),
                        new HitResult() { FromUnit = from, ToUnit = to, HitResultType = EHitResultType.Damage, Value = dmg });
                    break;
                }
                case EHitFromType.Skill_Bullet:
                {
                    int dmg = from.GetComponent<NumericComponent>().GetAsInt(NumericType.AttackDamage);
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.NowHp) - dmg;
                    to.GetComponent<NumericComponent>().Set(NumericType.NowHp, finalHp);
                    if (finalHp <= 0)
                    {
                        to.GetComponent<NumericComponent>().Set(NumericType.Death, 1);
                        // 死亡发事件通知
                        EventSystem.Instance.Publish(from.Root(), new UnitDeath() { AttackUnit = from, DefendUnit = to });
                    }

                    Log.Info($"hit settle, from:{from.Id}, to:{to.Id}, value:{dmg}");

                    EventSystem.Instance.Publish(from.Root(),
                        new HitResult() { FromUnit = from, ToUnit = to, HitResultType = EHitResultType.Damage, Value = dmg });
                    break;
                }
            }
        }

        public static int CalcuateDamageValue(Unit attackUnit, Unit TargetUnit)
        {
            int damage = attackUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.AttackDamage);
            // int dodge = TargetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Dodge);
            // int aromr = TargetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Armor);

            // 随机 0 - 100%  根据敏捷值进行闪避
            // int rate = RandomHelper.RandomNumber(0, 1000000);
            // Log.Debug("Rate:  " + rate.ToString());
            // if (rate < dodge)
            // {
            //     //躲避成功
            //     Log.Debug("闪避成功");
            //     damage = 0;
            // }

            // 免伤（物理）=护甲/（护甲+100）X100%
            // 假如潘森的护甲是40，潘森的物理免伤=40/140X100%=29%。在敌方没有任何护甲穿透的情况下，100点攻击力只能出现81点伤害。
            // 护甲削减：假如对面有100护甲，你有满层黑切24%的护甲削减，那么你攻击对面时对面的实际护甲就是100-100X24%=76%
            // 护甲穿透率就是百分比穿甲：假如对面100护甲，你有满层36%的护甲穿透率。那么你攻击对面时对面的实际护甲就是100-100X36%=64%
            // 护甲穿透其实就是固定穿甲，假如对面有100护甲，你有15的固定穿甲，那么你攻击对面时对面的实际护甲就是100-15=85点。
            // 实际护甲=护甲数X（1-护甲削减）X（1-百分比穿透）-固定穿甲
            // 假如护甲数为100，护甲削减10%，百分比穿透10%，固定穿甲10点，
            // 实际护甲=100X（1-10%）X（1-10%）-10=71

            // if (damage > 0)
            // {
            //     //扣掉护甲值
            //     damage = damage - aromr;
            //     //造成最小的1点伤害值
            //     damage = damage <= 0 ? 1 : damage;
            // }

            //Log.Debug($"造成伤害值：{damage}");
            return damage;
        }

        public static void SpellSkill(this Unit unit, int skillConfigId, long targetUnitId, float angle, float distance)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillConfigId);
            if (distance > skillConfig.SkillIndicatorParams[0])
            {
                distance = skillConfig.SkillIndicatorParams[0];
            }

            quaternion rotation = quaternion.Euler(0, math.radians(angle), 0);
            float3 position = unit.Position + math.mul(rotation, math.forward()) + distance;

            if (skillComponent.SpellSkill(skillConfigId, targetUnitId, position, angle))
            {
                M2C_SpellSkill m2CSpellSkill = M2C_SpellSkill.Create();
                m2CSpellSkill.UnitId = unit.Id;
                m2CSpellSkill.SkillConfigId = skillConfigId;
                m2CSpellSkill.TargetUnitId = targetUnitId;
                m2CSpellSkill.Position = position;
                m2CSpellSkill.Angle = angle;

                MapMessageHelper.Broadcast(unit, m2CSpellSkill);
            }
        }

        public static void AddSkill(this Unit unit, int skillConfigId)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            if (skillComponent.AddSkill(skillConfigId))
            {
                Skill skill = skillComponent.GetSkillByConfigId(skillConfigId);

                M2C_SkillUpdateOp m2CSkillUpdateOp = M2C_SkillUpdateOp.Create();
                m2CSkillUpdateOp.UnitId = unit.Id;
                m2CSkillUpdateOp.SkillOpType = (int)ESkillOpType.Add;
                m2CSkillUpdateOp.SkillInfo = skill.ToMessage();
            }
        }

        public static void RemoveSkill(this Unit unit, int skillConfigId)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            if (skillComponent.RemoveSkill(skillConfigId))
            {
                M2C_SkillUpdateOp m2CSkillUpdateOp = M2C_SkillUpdateOp.Create();
                m2CSkillUpdateOp.UnitId = unit.Id;
                m2CSkillUpdateOp.SkillOpType = (int)ESkillOpType.Remove;
                SkillInfo skillInfo = SkillInfo.Create();
                skillInfo.SkillConfigId = skillConfigId;
                m2CSkillUpdateOp.SkillInfo = skillInfo;
                foreach (KeyValuePair<int, int> keyValuePair in skillComponent.SkillSlotDict)
                {
                    KeyValuePair_Int_Int keyValuePairIntInt = KeyValuePair_Int_Int.Create();
                    keyValuePairIntInt.Key = keyValuePair.Key;
                    keyValuePairIntInt.Value = keyValuePair.Value;
                    m2CSkillUpdateOp.SkillGridDict.Add(keyValuePairIntInt);
                }
            }
        }

        public static void InterruptSkill(this Unit unit)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            List<EntityRef<Skill>> skills = skillComponent.GetAllSkill();
            foreach (Skill skill in skills)
            {
                if (skill.SkillState == ESkillState.Execute)
                {
                    skill.EndSpell();
                    M2C_SkillUpdateOp m2CSkillUpdateOp = M2C_SkillUpdateOp.Create();
                    m2CSkillUpdateOp.UnitId = unit.Id;
                    m2CSkillUpdateOp.SkillOpType = (int)ESkillOpType.Interrupt;
                    SkillInfo skillInfo = SkillInfo.Create();
                    skillInfo.SkillConfigId = skill.SkillConfigId;
                    m2CSkillUpdateOp.SkillInfo = skillInfo;
                }
            }
        }

        public static void SetSkillSlot(this Unit unit, int skillConfigId, ESkillSlotType skillSlotType)
        {
            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            if (skillComponent.SetSkillSlot(skillConfigId, skillSlotType))
            {
                M2C_SkillUpdateOp m2CSkillUpdateOp = M2C_SkillUpdateOp.Create();
                m2CSkillUpdateOp.UnitId = unit.Id;
                m2CSkillUpdateOp.SkillOpType = (int)ESkillOpType.SetSkillGrid;
                foreach (KeyValuePair<int, int> keyValuePair in skillComponent.SkillSlotDict)
                {
                    KeyValuePair_Int_Int keyValuePairIntInt = KeyValuePair_Int_Int.Create();
                    keyValuePairIntInt.Key = keyValuePair.Key;
                    keyValuePairIntInt.Value = keyValuePair.Value;
                    m2CSkillUpdateOp.SkillGridDict.Add(keyValuePairIntInt);
                }
            }
        }

        public static Unit GetEnemy(this Unit unit, float maxDistance, bool isNearest = true, EUnitType unitType = EUnitType.Invalid)
        {
            Unit nearest = null;
            float minDistance = maxDistance;
            List<Unit> units = unit.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit u = units[i];

                if (u == null)
                {
                    continue;
                }

                if (u.Id == unit.Id)
                {
                    continue;
                }

                if (unitType != EUnitType.Invalid && unit.UnitType != unitType)
                {
                    continue;
                }

                float dd = math.distance(u.Position, unit.Position);
                if (dd > maxDistance)
                {
                    continue;
                }

                RoleCastComponent aRole = unit.GetComponent<RoleCastComponent>();

                if (aRole == null)
                {
                    continue;
                }

                ERoleCast roleCast = aRole.GetRoleCastToTarget(u);

                if (roleCast != ERoleCast.Adverse)
                {
                    continue;
                }

                if (!isNearest)
                {
                    nearest = unit;
                    break;
                }

                if (dd < minDistance)
                {
                    minDistance = dd;
                    nearest = u;
                }
            }

            return nearest;
        }
    }
}