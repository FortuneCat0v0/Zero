namespace ET.Client
{
    [FriendOf(typeof (UIHotUpdateComponent))]
    [Event(SceneType.Demo)]
    public class OnPatchDownlodFailed_ShowFaileInfo: AEvent<Scene, OnPatchDownlodFailed>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownlodFailed args)
        {
            Log.Error($"下载资源失败: {args.FileName} {args.Error}");
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>().ProgressText.text = $"下载资源失败: {args.FileName} {args.Error}";
            await ETTask.CompletedTask;
        }
    }
}