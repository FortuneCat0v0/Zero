using System;
using System.Collections.Generic;
using ET.EventType;

namespace ET.Server
{
    [FriendOf(typeof(SkillComponent))]
    [FriendOf(typeof(SkillTimelineComponent))]
    [FriendOf(typeof(ActionEvent))]
    [EntitySystemOf(typeof(SkillTimelineComponent))]
    public static partial class SkillTimelineComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillTimelineComponent self, int skillId, int skillLevel)
        {
            //当前测试，一个事件一个字段，可以自己换成二维数组一个字段存多条事件数据
            self.SkillConfig = SkillConfigCategory.Instance.Get(skillId, skillLevel);
        }

        [EntitySystem]
        private static void FixedUpdate(this SkillTimelineComponent self)
        {
            using (ListComponent<long> list = ListComponent<long>.Create())
            {
                long timeNow = TimeInfo.Instance.ServerNow();
                foreach ((long key, Entity value) in self.Children)
                {
                    ActionEvent actionEvent = (ActionEvent)value;

                    if (timeNow > actionEvent.EventTriggerTime)
                    {
                        ActionEventComponent.Instance.Run(actionEvent,
                            new ActionEventData() { actionEventType = actionEvent.ActionEventType, owner = actionEvent.OwnerUnit });
                        list.Add(key);
                    }
                }

                foreach (long id in list)
                {
                    self.Remove(id);
                }
            }
        }

        public static void StartPlay(this SkillTimelineComponent self)
        {
            self.StartSpellTime = TimeInfo.Instance.ServerNow();
            self.InitEvents();
        }

        public static void InitEvents(this SkillTimelineComponent self)
        {
            try
            {
                for (int i = 0; i < self.SkillConfig.ActionEventIds.Count; i++)
                {
                    int actionEventId = self.SkillConfig.ActionEventIds[i];
                    ActionEventConfig actionEventConfig = ActionEventConfigCategory.Instance.Get(actionEventId);
                    if (actionEventConfig == null)
                        continue;
                    // #if DOTNET
                    //客户端渲染层的事件服务端不处理
                    if (actionEventConfig.IsClientOnly)
                        continue;
                    // #endif

                    // 事件触发时间计算来源
                    // 1. 技能：技能表的触发百分比 / 100 * 技能周期 ms
                    // 2. Buff：立即触发，EventTriggerTime = 0
                    // 3. Bullet：立即触发，EventTriggerTime = 0
                    int triggerTime = self.SkillConfig.ActionEventTriggerPercent[i] / 100 * self.SkillConfig.Life;
                    self.AddChild<ActionEvent, int, int, EActionEventSourceType>(actionEventId, triggerTime, EActionEventSourceType.Skill);
                }
            }
            catch (Exception e)
            {
                Log.Error($"事件id与事件触发时间百分比数量不一致， 技能id：{self.SkillConfig.Id}, lv:{self.SkillConfig.Level} \n{e}");
            }
        }

        private static void Remove(this SkillTimelineComponent self, long id)
        {
            if (!self.Children.TryGetValue(id, out Entity skillEvent))
            {
                return;
            }

            skillEvent.Dispose();
        }
    }
}