using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(ActionEvent))]
    [FriendOf(typeof(ActionEvent))]
    public static partial class ActionEventSystem
    {
        [EntitySystem]
        private static void Awake(this ActionEvent self, int configId, int triggerTime, EActionEventSourceType sourceType)
        {
            //事件触发时间计算来源
            //1. 技能：技能表的触发百分比 * 技能周期 / 1000 ms
            //2. Buff：立即触发，EventTriggerTime = 0
            //3. Bullet：立即触发，EventTriggerTime = 0
            self.ConfigId = configId;
            self.EventTriggerTime = triggerTime + TimeInfo.Instance.ServerNow();
            self.SourceType = sourceType;
            self.ActionEventType = self.ActionEventConfig.ActionEventType;
        }

        [EntitySystem]
        private static void Destroy(this ActionEvent self)
        {
        }

        public static void Transfer(this ActionEvent self)
        {
        }
    }
}