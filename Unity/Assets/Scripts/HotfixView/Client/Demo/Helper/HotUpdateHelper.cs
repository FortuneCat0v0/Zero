using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ResourcesLoaderComponent))]
    public static class HotUpdateHelper
    {
        public static async ETTask DownloadPatch(Scene root)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = root.GetComponent<ResourcesLoaderComponent>();

            // 下载资源
            Log.Info(
                $"Count: {resourcesLoaderComponent.Downloader.TotalDownloadCount}, Bytes: {resourcesLoaderComponent.Downloader.TotalDownloadBytes}");
            int errorCode = await resourcesLoaderComponent.DonwloadWebFilesAsync(
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
                    EventSystem.Instance.Publish(root, new OnPatchDownlodFailed() { FileName = fileName, Error = error });
                },

                // 下载完成回调
                (isSucceed) =>
                {
                    // 提示重启游戏
                    // EventSystem.Instance.Publish(root, new OnPatchDownlodOver() { IsSucceed = isSucceed });
                    GameObject.Find("Global").GetComponent<Init>().Restart().Coroutine();
                });

            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error("ResourceComponent.FsmDonwloadWebFiles 出错！{0}".Fmt(errorCode));
            }
        }
    }
}