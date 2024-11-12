namespace ET.Client
{
    public static partial class AssetPathHelper
    {
        public static string GetScenePath(string fileName)
        {
            return $"Assets/Bundles/Scenes/{fileName}.unity";
        }

        public static string GetUIPath(string fileName)
        {
            return $"Assets/Bundles/UI/{fileName}.prefab";
        }

        public static string GetUnitPath(string fileName)
        {
            return $"Assets/Bundles/Unit/{fileName}.prefab";
        }

        public static string GetEffectPath(string fileName)
        {
            return $"Assets/Bundles/Effect/{fileName}.prefab";
        }

        public static string GetItemIconPath(string fileName)
        {
            return $"Assets/Bundles/Icon/ItemIcon/{fileName}.png";
        }

        public static string GetAudioPlayerPath()
        {
            return $"Assets/Bundles/Audio/AudioPlayer.prefab";
        }

        public static string GetVoicePath(string fileName)
        {
            return $"Assets/Bundles/Audio/Voice/{fileName}";
        }

        public static string GetSoundPath(string fileName)
        {
            return $"Assets/Bundles/Audio/Sound/{fileName}";
        }

        public static string GetMusicPath(string fileName)
        {
            return $"Assets/Bundles/Audio/Music/{fileName}";
        }

        public static string GetItemQualityIconPath(int quality)
        {
            string fileName = quality switch
            {
                1 => "ItemQuality_1",
                2 => "ItemQuality_2",
                3 => "ItemQuality_3",
                4 => "ItemQuality_4",
                5 => "ItemQuality_5",
                6 => "ItemQuality_6",
                _ => ""
            };

            return $"Assets/Bundles/Icon/ItemQualityIcon/{fileName}.png";
        }

        public static string GetTextPath(string text)
        {
            string prefabPath = $"Assets/Bundles/Text/{text}.txt";

            return prefabPath;
        }
    }
}