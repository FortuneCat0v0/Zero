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

        # region Toggle相关

        public static void SetToggleShow(this GameObject gameObject, bool isShow)
        {
            gameObject.transform.Find("Background/Selected").gameObject.SetActive(isShow);
            gameObject.transform.Find("Background/UnSelected").gameObject.SetActive(!isShow);
        }

        public static void AddListener(this ToggleGroup toggleGroup, UnityAction<int> selectEventHandler)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                int index = i;
                togglesList[i].AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        selectEventHandler(index);
                    }
                });
            }
        }

        public static void AddListener(this Toggle toggle, UnityAction<bool> selectEventHandler)
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(selectEventHandler);
        }

        public static void SetTogglesInteractable(this ToggleGroup toggleGroup, bool isEnable)
        {
            var toggles = toggleGroup.transform.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].interactable = isEnable;
            }
        }

        public static (int, Toggle) GetSelectedToggle(this ToggleGroup toggleGroup)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (togglesList[i].isOn)
                {
                    return (i, togglesList[i]);
                }
            }

            Log.Error("none Toggle is Selected");
            return (-1, null);
        }

        public static void SetToggleSelected(this ToggleGroup toggleGroup, int index)
        {
            var togglesList = toggleGroup.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < togglesList.Length; i++)
            {
                if (i != index)
                {
                    continue;
                }

                togglesList[i].IsSelected(true);
            }
        }

        public static void IsSelected(this Toggle toggle, bool isSelected)
        {
            // Toggle Group 的 Allow Switch Off 默认设置为false时，会自动设置第一个Toggle.isOn = true，不触发回调
            // Toggle.isOn 只有改变才会触发回调，如果Toggle.isOn原本为true，那么isSelected=true不会触发回调
            // 所以这里要主动去触发下，但是要避免一种情况，Toggle.isOn由false->ture的时候不要主动触发，否则会触发2次
            if (toggle.isOn && isSelected)
            {
                toggle.onValueChanged?.Invoke(true);
            }

            toggle.isOn = isSelected;
        }

        #endregion

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

        # region Button 相关

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

        # endregion
    }
}