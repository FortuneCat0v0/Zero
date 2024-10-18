using UnityEngine;

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

        public static bool Check_GetMouseButtonDown0()
        {
            return (GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began));
        }
    }
}