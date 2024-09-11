using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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