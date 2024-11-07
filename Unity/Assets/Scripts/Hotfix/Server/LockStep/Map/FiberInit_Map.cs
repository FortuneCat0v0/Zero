namespace ET.Server
{
    [Invoke((long)SceneType.Map)]
    public class FiberInit_Map : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<UnitComponent>();
            root.AddComponent<AOIManagerComponent>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            root.AddComponent<CollisionWorldComponent>();
            root.AddComponent<MonsterManagerComponent>();

            MapComponent mapComponent = root.AddComponent<MapComponent>();
            string mapName = root.Name;
            switch (mapName)
            {
                case "Map1":
                {
                    mapComponent.MapType = MapType.Map1;
                    mapComponent.MapConfigId = 1001;

                    MapConfig mapConfig = MapConfigCategory.Instance.Get(mapComponent.MapConfigId);
                    // 生成特殊区域
                    foreach (int areaConfigId in mapConfig.AreaConfigIds)
                    {
                        UnitFactory.CreateArea(root, areaConfigId);
                    }

                    break;
                }
                case "Map2":
                {
                    mapComponent.MapType = MapType.Map2;
                    mapComponent.MapConfigId = 1002;

                    MapConfig mapConfig = MapConfigCategory.Instance.Get(mapComponent.MapConfigId);
                    // 生成特殊区域
                    foreach (int areaConfigId in mapConfig.AreaConfigIds)
                    {
                        UnitFactory.CreateArea(root, areaConfigId);
                    }

                    break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}