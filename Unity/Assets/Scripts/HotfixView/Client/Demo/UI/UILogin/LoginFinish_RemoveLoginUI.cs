﻿namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class LoginFinish_RemoveLoginUI : AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            await YIUIMgrComponent.Inst.ClosePanelAsync<LoginPanelComponent>(false, true);
            // scene.GetComponent<UIComponent>().Remove(UIType.UILogin);

            await ETTask.CompletedTask;
        }
    }
}