using Unity.Mathematics;

namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

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
                skillComponent.SkillGridDict[keyValuePairIntInt.Key] = keyValuePairIntInt.Value;
            }

            unit.AddComponent<ObjectWait>();

            // unit.AddComponent<XunLuoPathComponent>();

            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }
    }
}