using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(LoadingPanelComponent))]
    public static partial class LoadingPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this LoadingPanelComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this LoadingPanelComponent self)
        {
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this LoadingPanelComponent self)
        {
            self.IsComplete = false;
            self.Progress = 0;
            self.u_ComLoadingSlider.value = 0;

            await ETTask.CompletedTask;
            return true;
        }

        [EntitySystem]
        private static void Update(this LoadingPanelComponent self)
        {
            if (self.IsComplete == false && self.Progress >= 0.8f)
            {
                return;
            }

            self.Progress += Time.deltaTime;

            if (self.Progress >= 1)
            {
                YIUIMgrComponent.Inst.ClosePanelAsync<LoadingPanelComponent>(false, true).Coroutine();
                return;
            }

            self.u_ComLoadingSlider.value = self.Progress;
        }

        public static void SetComplete(this LoadingPanelComponent self)
        {
            self.IsComplete = true;
        }

        #region YIUIEvent开始

        #endregion YIUIEvent结束
    }
}