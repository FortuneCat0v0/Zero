using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    public static class InputHelper
    {
        public static bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }

        public static bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }

        public static bool GetMouseButtonDown(int code)
        {
            return Input.GetMouseButtonDown(code);
        }

        /// <summary>
        /// 判断是否发生了点击或触摸开始事件
        /// </summary>
        /// <returns></returns>
        public static bool IsClickOrTouchBegan(int code = 0)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return Input.GetMouseButtonDown(code);
#elif UNITY_IOS || UNITY_ANDROID
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#else
            return false;
#endif
        }

        /// <summary>
        /// 判断当前点击或触摸是否在UI元素上
        /// </summary>
        /// <returns></returns>
        public static bool IsPointerOverUI()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
#elif UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            }

            return false;
#else
            return false;
#endif
        }

        // /// <summary>
        // /// 检测是否点击UI
        // /// </summary>
        // /// <param name="mousePosition"></param>
        // /// <returns></returns>
        // public static bool IsPointerOverGameObject(Vector2 mousePosition)
        // {
        //     // 创建一个点击事件
        //     PointerEventData eventData = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        //     eventData.position = mousePosition;
        //     List<RaycastResult> raycastResults = new List<RaycastResult>();
        //     // 向点击位置发射一条射线，检测是否点击UI
        //     UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData, raycastResults);
        //     if (raycastResults.Count > 0)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
    }
}