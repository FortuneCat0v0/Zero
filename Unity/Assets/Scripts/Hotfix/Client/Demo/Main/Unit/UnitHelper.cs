﻿namespace ET.Client
{
    public static partial class UnitHelper
    {
        public static Unit GetMyUnitFromClientScene(Scene root)
        {
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            Scene currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene.Root().GetComponent<PlayerComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static Unit GetUnitById(Scene root, long unitId)
        {
            Scene currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(unitId);
        }

        public static bool IsMyUnit(this Unit unit)
        {
            PlayerComponent playerComponent = unit.Root().GetComponent<PlayerComponent>();
            return unit.Id == playerComponent.MyId;
        }
    }
}