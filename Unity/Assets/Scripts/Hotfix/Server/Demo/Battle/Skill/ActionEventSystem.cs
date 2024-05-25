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