﻿namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, EUnitType, int>(unitInfo.UnitId, (EUnitType)unitInfo.EUnitType, unitInfo.ConfigId);
            unitComponent.Add(unit);

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            switch (unit.UnitType)
            {
                case EUnitType.Player:
                case EUnitType.Monster:
                case EUnitType.Skill:
                {
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

                    foreach (var kv in unitInfo.KV)
                    {
                        numericComponent.Set(kv.Key, kv.Value);
                    }

                    unit.AddComponent<MoveComponent>();
                    if (unitInfo.MoveInfo != null)
                    {
                        if (unitInfo.MoveInfo.Points.Count > 0)
                        {
                            unitInfo.MoveInfo.Points[0] = unit.Position;
                            unit.MoveToAsync(unitInfo.MoveInfo.Points).Coroutine();
                        }
                    }

                    SkillComponent skillComponent = unit.AddComponent<SkillComponent>();
                    foreach (SkillInfo skillInfo in unitInfo.SkillInfos)
                    {
                        Skill skill = currentScene.AddChildWithId<Skill>(skillInfo.Id);
                        skill.FromMessage(skillInfo);
                        skillComponent.AddSkill(skill);
                    }

                    foreach (KeyValuePair_Int_Int keyValuePairIntInt in unitInfo.SkillGridDict)
                    {
                        skillComponent.SkillSlotDict[keyValuePairIntInt.Key] = keyValuePairIntInt.Value;
                    }

                    unit.AddComponent<BuffComponent>();

                    unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>((ERoleCamp)unitInfo.ERoleCamp, ERoleTag.Hero);

                    unit.AddComponent<ObjectWait>();
                    break;
                }
                case EUnitType.Item:
                {
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

                    foreach (var kv in unitInfo.KV)
                    {
                        numericComponent.Set(kv.Key, kv.Value);
                    }

                    break;
                }
            }

            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }
    }
}