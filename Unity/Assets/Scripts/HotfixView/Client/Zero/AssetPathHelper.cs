namespace ET.Client
{
    public static partial class AssetPathHelper
    {
        public const string PetHeadIcon = "PetHeadIcon";
        public const string PetSkillIcon = "PetSkillIcon";
        public const string RoleSkillIcon = "RoleSkillIcon";
        public const string TianFuIcon = "TianFuIcon";
        public const string ChapterIcon = "ChapterIcon";
        public const string PropertyIcon = "PropertyIcon";
        public const string ChengJiuIcon = "ChengJiuIcon";
        public const string RechageIcon = "RechageIcon";
        public const string MonsterIcon = "MonsterIcon";
        public const string TiTleIcon = "TiTleIcon";
        public const string TaskIcon = "TaskIcon";
        public const string OtherIcon = "OtherIcon";
        public const string PlayerIcon = "PlayerIcon";
        public const string ChengHaoIcon = "ChengHaoIcon";
        public const string MulLanguageIcon = "MulLanguageIcon";

        public static string GetItemIconPath(string fileName)
        {
            return $"Assets/Bundles/Icon/ItemIcon/{fileName}.png";
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

        public static string GetTexturePath(string fileName)
        {
            return $"Assets/Bundles/Altas/{fileName}.prefab";
        }

        public static string ToUIPath(this string fileName)
        {
            return $"Assets/Bundles/UI/Dlg/{fileName}.prefab";
        }

        public static string ToUISpriteAtlasPath(this string fileName)
        {
            return $"Assets/Res/UIAtlas/{fileName}.spriteatlas";
        }

        public static string GetNormalConfigPath(string fileName)
        {
            return $"Assets/Bundles/Independent/{fileName}.prefab";
        }

        public static string ToSoundPath(this string fileName)
        {
            return $"Assets/Bundles/Sound/{fileName}.mp3";
        }

        public static string ToConfigPath(this string fileName)
        {
            return $"Assets/Bundles/Config/{fileName}.bytes";
        }

        public static string ToSQLiteDBPath(this string fileName)
        {
            return $"Assets/Bundles/SQLiteDB/{fileName}.db";
        }

        public static string GetSkillConfigPath(string fileName)
        {
            return $"Assets/Bundles/SkillConfigs/{fileName}.prefab";
        }

        public static string ToPrefabPath(this string fileName)
        {
            return $"Assets/Bundles/Prefab/{fileName}.prefab";
        }

        public static string GetScenePath(this string fileName)
        {
            return $"Assets/Bundles/Scenes/{fileName}.unity";
        }

        public static string ToUICommonPath(this string fileName)
        {
            return $"Assets/Bundles/UI/Common/{fileName}.prefab";
        }

        public static string ToUIItemPath(this string fileName)
        {
            return $"Assets/Bundles/UI/Item/{fileName}.prefab";
        }

        public static string ToUnitModelPath(this string fileName)
        {
            return $"Assets/Bundles/Unit/{fileName}.prefab";
        }

        public static string ToUnitHUDPath(this string fileName)
        {
            return $"Assets/Bundles/UnitHUD/{fileName}HUD.prefab";
        }
    }
}