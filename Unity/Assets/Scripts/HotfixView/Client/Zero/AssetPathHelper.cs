namespace ET.Client
{
    public static partial class AssetPathHelper
    {
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