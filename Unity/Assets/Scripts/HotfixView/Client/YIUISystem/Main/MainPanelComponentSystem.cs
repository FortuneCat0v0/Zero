using System;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(MainPanelComponent))]
    public static partial class MainPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this MainPanelComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MainPanelComponent self)
        {
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this MainPanelComponent self)
        {
            self.UIPanel.OpenViewAsync<JoystickViewComponent>().Coroutine();
            self.UIPanel.OpenViewAsync<MiniMapViewComponent>().Coroutine();

            await ETTask.CompletedTask;
            return true;
        }

        [EntitySystem]
        private static void Update(this MainPanelComponent self)
        {
            self.u_ComPingTextMeshProUGUI.text = $"{TimeInfo.Instance.Ping} ms";
        }

        #region YIUIEvent开始

        #endregion YIUIEvent结束
    }
}