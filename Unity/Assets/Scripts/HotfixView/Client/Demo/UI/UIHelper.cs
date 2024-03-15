using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    public static class UIHelper
    {
        [EnableAccessEntiyChild]
        public static async ETTask<UI> Create(Entity scene, string uiType, UILayer uiLayer)
        {
            return await scene.GetComponent<UIComponent>().Create(uiType, uiLayer);
        }

        [EnableAccessEntiyChild]
        public static void Remove(Entity scene, string uiType)
        {
            scene.GetComponent<UIComponent>().Remove(uiType);
        }

        # region 点击注册

        public static void AddEventTrigger(this EventTrigger eventTrigger, Action<PointerEventData> action, EventTriggerType etype)
        {
            EventTrigger.Entry entry = new();
            entry.eventID = etype;
            entry.callback.AddListener(Callback);
            eventTrigger.triggers.Add(entry);
            return;

            void Callback(BaseEventData eventdata)
            {
                PointerEventData data = eventdata as PointerEventData;
                action(data);
            }
        }

        /// <summary>
        /// 按钮注册 异步
        /// </summary>
        /// <param name="button"></param>
        /// <param name="action"></param>
        public static void AddListenerAsync(this Button button, Func<ETTask> action)
        {
            button.onClick.RemoveAllListeners();

            async ETTask clickAcionAsync()
            {
                UIEventComponent.Instance.IsClicked = true;
                await action();
                UIEventComponent.Instance.IsClicked = false;
            }

            button.onClick.AddListener(() =>
            {
                if (UIEventComponent.Instance.IsClicked)
                {
                    return;
                }

                clickAcionAsync().Coroutine();
            });
        }

        /// <summary>
        /// 按钮注册
        /// </summary>
        /// <param name="button"></param>
        /// <param name="clickEventHandler"></param>
        public static void AddListener(this Button button, UnityAction clickEventHandler)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(clickEventHandler);
        }

        #endregion
    }
}