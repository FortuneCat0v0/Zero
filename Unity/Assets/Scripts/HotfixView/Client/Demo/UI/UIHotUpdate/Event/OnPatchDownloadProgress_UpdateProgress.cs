namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class OnPatchDownloadProgress_UpdateProgress: AEvent<Scene, OnPatchDownloadProgress>
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
}