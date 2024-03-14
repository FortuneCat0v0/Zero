using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            self.ProgressBarImg = rc.Get<GameObject>("ProgressBarImg").GetComponent<Image>();
            self.ProgressText = rc.Get<GameObject>("ProgressText").GetComponent<TMP_Text>();
        }

        public static void OnPatchDownloadProgress(this UIHotUpdateComponent self, int totalDownloadCount, int currentDownloadCount,
        long totalDownloadBytes, long currentDownloadBytes)
        {
            self.ProgressBarImg.fillAmount = currentDownloadBytes * 1f / totalDownloadBytes;
            self.ProgressText.text =
                    $"下载资源 {currentDownloadBytes / 1048576f:0.##}/{totalDownloadBytes / 1048576f:0.##} MB";
        }

        public static void ShowPackageVersion(this UIHotUpdateComponent self, string packageVersion)
        {
            self.PackageVersionText.GetComponent<TMP_Text>().text = $"当前资源版本：{packageVersion}";
        }
    }
}