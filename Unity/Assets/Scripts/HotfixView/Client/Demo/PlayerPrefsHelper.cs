using UnityEngine;

namespace ET.Client
{
    public static class PlayerPrefsHelper
    {
        public const string LastAccount = "Zero_LastAccount";
        public const string LastPassword = "Zero_LastPassword";
        public const string LastRole = "Zero_LastRole";
        public const string SoundVolume = "Zero_SoundVolume";
        public const string MusicVolume = "Zero_MusicVolume";

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public static float GetFloat(string key, float defaultValue = 0)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public static string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }
}