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
            // hotUpdatePanelComponent.ShowPackageVersion(args.PackageVersion);
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
    }
}