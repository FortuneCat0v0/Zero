namespace ET.Client
{
    [FriendOf(typeof(UIHotUpdateComponent))]
    [Event(SceneType.Demo)]
    public class OnPatchDownlodOver_Reset : AEvent<Scene, OnPatchDownlodOver>
    {
        protected override async ETTask Run(Scene scene, OnPatchDownlodOver args)
        {
            UI ui = scene.GetComponent<UIComponent>().Get(UIType.UIHotUpdate);
            ui.GetComponent<UIHotUpdateComponent>().ProgressText.text = "资源更新完成，请重启游戏";
            await ETTask.CompletedTask;
        }
    }
}