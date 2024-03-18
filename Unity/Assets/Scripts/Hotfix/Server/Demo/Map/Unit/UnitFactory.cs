using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit;
            NumericComponent numericComponent;
            switch (unitType)
            {
                case UnitType.Player:
                {
                    unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);

                    numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f, false); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米

                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    unit.AddComponent<BagComponent>();
                    return unit;
                }
                case UnitType.Monster:
                    unit = unitComponent.AddChildWithId<Unit, int>(id, 1002);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);

                    numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(NumericType.Speed, 6f, false); // 速度是6米每秒
                    numericComponent.Set(NumericType.AOI, 15000, false); // 视野15米

                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    unit.AddComponent<PathfindingComponent, string>(scene.Name);
                    unit.AddComponent<XunLuoPathComponent>();
                    unit.AddComponent<AIComponent, int>(2);
                    return unit;
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}