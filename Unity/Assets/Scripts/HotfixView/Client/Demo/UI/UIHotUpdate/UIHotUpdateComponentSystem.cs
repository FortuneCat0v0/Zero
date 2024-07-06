using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class StartHotUpDate_CreatHotUpdateUI : AEvent<Scene, StartHotUpDate>
    {
        protected override async ETTask Run(Scene scene, StartHotUpDate args)
        {
            UI ui = await UIHelper.Create(scene, UIType.UIHotUpdate, UILayer.Mid);
            ui.GetComponent<UIHotUpdateComponent>().ShowPackageVersion(args.PackageVersion);
        }
    }

    [Event(SceneType.Demo)]
    public class HaveDownloader_TipUI : AEvent<Scene, HaveDownloader>
    {
        protected override async ETTask Run(Scene scene, HaveDownloader args)
        {
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>().ShowTipPanel(args.TotalDownloadBytes);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class OnPatchDownloadProgress_UpdateProgress : AEvent<Scene, OnPatchDownloadProgress>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownloadProgress args)
        {
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>()?.OnPatchDownloadProgress(args.TotalDownloadCount,
                args.CurrentDownloadCount,
                args.TotalDownloadSizeBytes,
                args.CurrentDownloadSizeBytes);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class OnPatchDownlodFailed_ShowFaileInfo : AEvent<Scene, OnPatchDownlodFailed>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownlodFailed args)
        {
            Log.Error($"下载资源失败: {args.FileName} {args.Error}");
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>().ProgressText.GetComponent<TMP_Text>().text = $"下载资源失败: {args.FileName} {args.Error}";
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UIHotUpdateComponent))]
    [Event(SceneType.Demo)]
    public class OnPatchDownlodOver_Reset : AEvent<Scene, OnPatchDownlodOver>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownlodOver args)
        {
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>().ProgressText.GetComponent<TMP_Text>().text = "资源更新完成，请重启游戏";
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UIHotUpdateComponent))]
    [EntitySystemOf(typeof(UIHotUpdateComponent))]
    public static partial class UIHotUpdateComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIHotUpdateComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.PackageVersionText = rc.Get<GameObject>("PackageVersionText");
            self.ProgressText = rc.Get<GameObject>("ProgressText");
            self.ProgressBarImg = rc.Get<GameObject>("ProgressBarImg");
            self.TipPanel = rc.Get<GameObject>("TipPanel");
            self.TipText = rc.Get<GameObject>("TipText");
            self.StartDownloadBtn = rc.Get<GameObject>("StartDownloadBtn");

            self.StartDownloadBtn.GetComponent<Button>().AddListener(() =>
            {
                HotUpdateHelper.DownloadPatch(self.Root()).Coroutine();
                self.TipPanel.SetActive(false);
            });

            self.TipPanel.SetActive(false);
        }

        public static void OnPatchDownloadProgress(this UIHotUpdateComponent self, int totalDownloadCount, int currentDownloadCount,
        long totalDownloadBytes, long currentDownloadBytes)
        {
            self.ProgressBarImg.GetComponent<Image>().fillAmount = currentDownloadBytes * 1f / totalDownloadBytes;
            self.ProgressText.GetComponent<TMP_Text>().text =
                    $"下载资源 {currentDownloadBytes / 1048576f:0.##}/{totalDownloadBytes / 1048576f:0.##} MB";
        }

        public static void ShowPackageVersion(this UIHotUpdateComponent self, string packageVersion)
        {
            self.PackageVersionText.GetComponent<TMP_Text>().text = $"当前资源版本：{packageVersion}";
        }

        public static void ShowTipPanel(this UIHotUpdateComponent self, long totalDownloadBytes)
        {
            self.TipPanel.SetActive(true);
            self.TipText.GetComponent<TMP_Text>().text = $"需要更新的资源大小为{totalDownloadBytes / 1048576f:0.##} MB";
        }
    }
}