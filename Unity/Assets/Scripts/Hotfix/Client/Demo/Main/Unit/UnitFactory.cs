namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, UnitType, int>(unitInfo.UnitId, (UnitType)unitInfo.EUnitType, unitInfo.ConfigId);
            unitComponent.Add(unit);

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            switch (unit.UnitType)
            {
                case UnitType.Player:
                case UnitType.Monster:
                case UnitType.Skill:
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

                    ClientSkillComponent clientSkillComponent = unit.AddComponent<ClientSkillComponent>();
                    foreach (SkillInfo skillInfo in unitInfo.SkillInfos)
                    {
                        ClientSkill clientSkill = currentScene.AddChildWithId<ClientSkill>(skillInfo.Id);
                        clientSkill.FromMessage(skillInfo);
                        clientSkillComponent.AddSkill(clientSkill);
                    }

                    foreach (KeyValuePair_Int_Int keyValuePairIntInt in unitInfo.SkillGridDict)
                    {
                        clientSkillComponent.SkillSlotDict[keyValuePairIntInt.Key] = keyValuePairIntInt.Value;
                    }

                    unit.AddComponent<BuffCComponent>();

                    unit.AddComponent<RoleCastComponent, ERoleCamp, ERoleTag>((ERoleCamp)unitInfo.ERoleCamp, ERoleTag.Hero);

                    unit.AddComponent<ObjectWait>();
                    break;
                }
                case UnitType.Item:
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