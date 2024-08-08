using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 检测UI是否引用了Bundles中非UI的文件，请引用Bundles外的图片资源
    /// </summary>
    public class UIRefCheckTool : MonoBehaviour
    {
        private const string prefabFolderPath = "Assets/Bundles/UI";
        private const string assetsFolderPath = "Assets/Bundles";

        [MenuItem("Tools/检测UI引用")]
        public static void CheckDependencies()
        {
            if (!Directory.Exists(prefabFolderPath) || !Directory.Exists(assetsFolderPath))
            {
                Debug.LogError("Invalid folder path(s).");
                return;
            }

            Log.Debug("检测开始");

            string[] prefabPaths = Directory.GetFiles(prefabFolderPath, "*.prefab", SearchOption.AllDirectories);
            Dictionary<string, List<string>> prefabDependencies = new Dictionary<string, List<string>>();

            foreach (string prefabPath in prefabPaths)
            {
                string[] dependencies = AssetDatabase.GetDependencies(prefabPath, true);
                List<string> assetDependencies = new List<string>();

                foreach (string dependency in dependencies)
                {
                    if (dependency.StartsWith(assetsFolderPath) && !dependency.StartsWith(prefabFolderPath) && dependency != prefabPath)
                    {
                        assetDependencies.Add(dependency);
                    }
                }

                prefabDependencies[prefabPath] = assetDependencies;
            }

            PrintDependencies(prefabDependencies);

            Log.Debug("检测完毕");
        }

        private static void PrintDependencies(Dictionary<string, List<string>> prefabDependencies)
        {
            foreach (var kvp in prefabDependencies)
            {
                string prefabPath = kvp.Key;
                List<string> dependencies = kvp.Value;

                if (dependencies.Count > 0)
                {
                    foreach (string dependency in dependencies)
                    {
                        Debug.Log($"Prefab: {prefabPath}    Dependency: {dependency}");
                    }
                }
            }
        }
    }
}