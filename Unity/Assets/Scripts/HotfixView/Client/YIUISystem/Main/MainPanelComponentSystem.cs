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

            self.UISkillSlotItem_0.SetSkill(ESkillSlotType.Slot_0);
            self.UISkillSlotItem_1.SetSkill(ESkillSlotType.Slot_1);
            self.UISkillSlotItem_2.SetSkill(ESkillSlotType.Slot_2);
            self.UISkillSlotItem_3.SetSkill(ESkillSlotType.Slot_3);

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