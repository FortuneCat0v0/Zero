namespace ET.Client
{
    public static partial class SceneChangeHelper
    {
        public static async ETTask SceneChangeTo(Scene root, long sceneInstanceId, MapType mapType, int mapConfigId)
        {
            CurrentScenesComponent currentScenesComponent = root.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = CurrentSceneFactory.Create(sceneInstanceId, "Map", currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();

            MapComponent mapComponent = currentScene.AddComponent<MapComponent>();
            mapComponent.MapType = mapType;
            mapComponent.MapConfigId = mapConfigId;

            // 可以订阅这个事件中创建Loading界面
            EventSystem.Instance.Publish(currentScene, new SceneChangeStart());

            // 等待CreateMyUnit的消息
            Wait_CreateMyUnit waitCreateMyUnit = await root.GetComponent<ObjectWait>().Wait<Wait_CreateMyUnit>();
            M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            unitComponent.Add(unit);

            EventSystem.Instance.Publish(currentScene, new SceneChangeFinish());

            // 通知等待场景切换的协程
            root.GetComponent<ObjectWait>().Notify(new Wait_SceneChangeFinish());
        }
    }
}