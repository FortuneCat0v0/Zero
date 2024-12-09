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
            root.AddComponent<AOIManagerComponent>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();

            root.AddComponent<UnitComponent>();
            root.AddComponent<CollisionWorldComponent>();
            root.AddComponent<MonsterManagerComponent>();

            MapComponent mapComponent = root.AddComponent<MapComponent>();
            mapComponent.MapType = MapType.MainMap;
            mapComponent.MapConfigId = 1001;

            // MapConfig mapConfig = MapConfigCategory.Instance.Get(mapComponent.MapConfigId);
            // 生成特殊区域
            // foreach (int areaConfigId in mapConfig.AreaConfigIds)
            // {
            //     UnitFactory.CreateArea(root, areaConfigId);
            // }

            await ETTask.CompletedTask;
        }
    }
}