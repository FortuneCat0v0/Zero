using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using Object = UnityEngine.Object;

namespace MekaruStudios.MonsterCreator
{
    public class AssetDatabaseExtension
    {
        public static List<T> GetAllAssets<T>() where T : Object
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            return guids
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<T>)
                .ToList();
        }

        public static T GetAsset<T>() where T : Object
        {
            var allAssets = GetAllAssets<T>();
            if (allAssets.Count == 0)
                throw new InvalidOperationException(
                    $"Tried to get the asset of type {typeof(T)}, but couldn't find any asset");
            
            return GetAllAssets<T>()[0];
        }
    }

}
