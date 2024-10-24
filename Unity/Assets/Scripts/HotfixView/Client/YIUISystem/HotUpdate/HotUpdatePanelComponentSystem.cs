using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using TMPro;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class StartHotUpDate_CreatHotUpdateUI : AEvent<Scene, StartHotUpDate>
    {
        protected override async ETTask Run(Scene scene, StartHotUpDate args)
        {
            HotUpdatePanelComponent hotUpdatePanelComponent = await YIUIMgrComponent.Inst.Root.OpenPanelAsync<HotUpdatePanelComponent>();
            hotUpdatePanelComponent.ShowPackageVersion(args.PackageVersion);
        }
    }

    [Event(SceneType.Demo)]
    public class OnPatchDownloadProgress_UpdateProgress : AEvent<Scene, OnPatchDownloadProgress>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownloadProgress args)
        {
            HotUpdatePanelComponent hotUpdatePanelComponent = YIUIMgrComponent.Inst.GetPanel<HotUpdatePanelComponent>();
            hotUpdatePanelComponent.OnPatchDownloadProgress(args.TotalDownloadCount,
                args.CurrentDownloadCount,
                args.TotalDownloadSizeBytes,
                args.CurrentDownloadSizeBytes);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class OnPatchDownloadFailed_ShowFailedInfo : AEvent<Scene, OnPatchDownloadFailed>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownloadFailed args)
        {
            HotUpdatePanelComponent hotUpdatePanelComponent = YIUIMgrComponent.Inst.GetPanel<HotUpdatePanelComponent>();
            hotUpdatePanelComponent.ShowTip($"下载资源失败: {args.FileName} {args.Error}");
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class OnPatchDownloadOver_Reset : AEvent<Scene, OnPatchDownloadOver>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownloadOver args)
        {
            HotUpdatePanelComponent hotUpdatePanelComponent = YIUIMgrComponent.Inst.GetPanel<HotUpdatePanelComponent>();
            hotUpdatePanelComponent.ShowTip("资源更新完成，请重启游戏");
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(HotUpdatePanelComponent))]
    public static partial class HotUpdatePanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this HotUpdatePanelComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this HotUpdatePanelComponent self)
        {
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this HotUpdatePanelComponent self)
        {
            await ETTask.CompletedTask;
            return true;
        }

        #region YIUIEvent开始

        #endregion YIUIEvent结束

        public static void OnPatchDownloadProgress(this HotUpdatePanelComponent self, int totalDownloadCount, int currentDownloadCount,
        long totalDownloadBytes, long currentDownloadBytes)
        {
            self.u_ComProgressBarImg.fillAmount = currentDownloadBytes * 1f / totalDownloadBytes;
            self.u_ComProgressTxt.text = $"下载资源 {currentDownloadBytes / 1048576f:0.##}/{totalDownloadBytes / 1048576f:0.##} MB";
        }

        public static void ShowPackageVersion(this HotUpdatePanelComponent self, string packageVersion)
        {
            self.u_ComPackageVersionTxt.text = $"当前资源版本：{packageVersion}";
        }

        public static void ShowTip(this HotUpdatePanelComponent self, string tip)
        {
            self.u_ComProgressTxt.text = tip;
        }
    }
}