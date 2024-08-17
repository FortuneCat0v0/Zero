namespace ET.Client
{
    [FriendOf(typeof(ResourcesLoaderComponent))]
    [Event(SceneType.Main)]
    public class EntryEvent3_InitClient : AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<UIGlobalComponent>();
            root.AddComponent<UIComponent>();
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<FlyTipComponent>();
            root.AddComponent<AccountComponent>();
            root.AddComponent<GameServerComponent>();
            root.AddComponent<RoleComponent>();
            root.AddComponent<SkillIndicatorComponent>();
            root.AddComponent<BagComponent>();
            root.AddComponent<EquipmentComponent>();
            root.AddComponent<MaskWordComponent>();

            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;

            // 热更流程
            StartHotUpdate(root).Coroutine();

            await ETTask.CompletedTask;
        }

        private static async ETTask StartHotUpdate(Scene root)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = root.GetComponent<ResourcesLoaderComponent>();

            await EventSystem.Instance.PublishAsync(root, new StartHotUpDate() { PackageVersion = resourcesLoaderComponent.PackageVersion });

            // 更新版本号
            int errorCode = await resourcesLoaderComponent.UpdateVersionAsync();
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error($"FsmUpdateStaticVersion 出错！{errorCode}");
                return;
            }

            // 更新Manifest
            errorCode = await resourcesLoaderComponent.UpdateManifestAsync();
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error($"ResourceComponent.UpdateManifest 出错！{errorCode}");
                return;
            }

            // 创建下载器
            errorCode = resourcesLoaderComponent.CreateDownloader();
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error($"ResourceComponent.FsmCreateDownloader 出错！{errorCode}");
                return;
            }

            // Downloader不为空，说明有需要下载的资源
            if (resourcesLoaderComponent.Downloader != null)
            {
                EventSystem.Instance.Publish(root,
                    new HaveDownloader() { TotalDownloadBytes = resourcesLoaderComponent.Downloader.TotalDownloadBytes });
            }
            else
            {
                // 等个几秒，不然看不到。。。
                await root.GetComponent<TimerComponent>().WaitAsync(2000);
                EventSystem.Instance.Publish(root, new AppStartInitFinish());
            }
        }
    }
}