using System;
using System.Collections.Generic;
using ET.EventType;

namespace ET
{
    /// <summary>
    /// 技能事件组件,分发监听
    /// </summary>
    [FriendOf(typeof(ActionEvent))]
    [Code]
    public class ActionEventComponent : Singleton<ActionEventComponent>, ISingletonAwake
    {
        private Dictionary<EActionEventType, List<IActionEvent>> allWatchers = new();

        public void Awake()
        {
            HashSet<Type> types = CodeTypes.Instance.GetTypes(typeof(ActionEventAttribute));
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(ActionEventAttribute), false);

                foreach (object attr in attrs)
                {
                    ActionEventAttribute actionEventAttribute = (ActionEventAttribute)attr;
                    IActionEvent obj = (IActionEvent)Activator.CreateInstance(type);
                    if (!this.allWatchers.ContainsKey(actionEventAttribute.ActionEventType))
                    {
                        this.allWatchers.Add(actionEventAttribute.ActionEventType, new List<IActionEvent>());
                    }

                    this.allWatchers[actionEventAttribute.ActionEventType].Add(obj);
                }
            }
        }

        /// <summary>
        /// 技能时间轴执行到对应技能事件调用此分发，传入参数，去执行相对应事件逻辑
        /// </summary>
        /// <param name="actionEvent"></param>
        /// <param name="args"></param>
        public void Run(ActionEvent actionEvent, ActionEventData args)
        {
            List<IActionEvent> list;
            if (!this.allWatchers.TryGetValue(actionEvent.ActionEventType, out list))
            {
                return;
            }

            // TODO 这里应该要和NumericWatcherComponent一样对不同的SceneType分发
            foreach (IActionEvent iActionEvent in list)
            {
                iActionEvent.Run(actionEvent, args);
            }
        }
    }
}