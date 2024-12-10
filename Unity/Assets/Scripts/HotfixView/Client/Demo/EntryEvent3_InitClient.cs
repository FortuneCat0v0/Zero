using YIUIFramework;

namespace ET.Client
{
    [FriendOf(typeof(ResourcesLoaderComponent))]
    [Event(SceneType.Main)]
    public class EntryEvent3_InitClient : AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            root.AddComponent<GlobalComponent>();
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<PlayerComponent>();
            // root.AddComponent<FlyTipComponent>();
            root.AddComponent<AccountComponent>();
            root.AddComponent<GameServerComponent>();
            root.AddComponent<RoleComponent>();
            root.AddComponent<SkillIndicatorComponent>();
            root.AddComponent<ClientKnapsackComponent>();
            root.AddComponent<ClientPetComponent>();
            root.AddComponent<EquipmentComponent>();
            root.AddComponent<ChatComponent>();
            // root.AddComponent<MaskWordComponent>();

            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(root.GetComponent<GlobalComponent>().GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;

            // YIUI初始化
            YIUIBindHelper.InternalGameGetUIBindVoFunc = YIUICodeGenerated.YIUIBindProvider.Get;
            await root.AddComponent<YIUIMgrComponent>().Initialize();
            // 根据需求自行处理 在editor下自动打开  也可以根据各种外围配置 或者 GM等级打开
            if (Define.IsEditor)
            {
                root.AddComponent<GMCommandComponent>();
            }

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
                // 下载资源
                Log.Info(
                    $"Count: {resourcesLoaderComponent.Downloader.TotalDownloadCount}, Bytes: {resourcesLoaderComponent.Downloader.TotalDownloadBytes}");
                errorCode = await resourcesLoaderComponent.DownloadWebFilesAsync(
                    // 开始下载回调
                    null,

                    // 下载进度回调
                    (totalDownloadCount, currentDownloadCount, totalDownloadBytes, currentDownloadBytes) =>
                    {
                        // 更新进度条
                        EventSystem.Instance.Publish(root,
                            new OnPatchDownloadProgress()
                            {
                                TotalDownloadCount = totalDownloadCount,
                                CurrentDownloadCount = currentDownloadCount,
                                TotalDownloadSizeBytes = totalDownloadBytes,
                                CurrentDownloadSizeBytes = currentDownloadBytes
                            });
                    },

                    // 下载失败回调
                    (fileName, error) =>
                    {
                        // 下载失败
                        EventSystem.Instance.Publish(root, new OnPatchDownloadFailed() { FileName = fileName, Error = error });
                    },

                    // 下载完成回调
                    (isSucceed) =>
                    {
                        // 提示重启游戏
                        EventSystem.Instance.Publish(root, new OnPatchDownloadOver() { IsSucceed = isSucceed });
                        // GameObject.Find("Global").GetComponent<Init>().Restart().Coroutine();
                    });
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