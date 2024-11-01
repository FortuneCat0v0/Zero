using System;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class FileSaver : IFileSaver
    {

        public void Save(GameObject objectToSave, string path)
        {
            if (objectToSave == null)
                throw new ArgumentNullException(nameof(objectToSave));
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            var prefab = PrefabUtility.SaveAsPrefabAsset(objectToSave, path);

#if UNITY_EDITOR
            if (prefab != null)
                Debug.Log("Prefab saved at path: " + path);
            else
                Debug.LogError("Failed to save prefab.");
#endif
        }
    }
}
