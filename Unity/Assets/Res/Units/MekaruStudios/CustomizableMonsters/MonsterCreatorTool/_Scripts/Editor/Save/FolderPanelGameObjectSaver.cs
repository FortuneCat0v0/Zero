using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public static class FolderPanelGameObjectSaver
    {

        public static void Save(GameObject gameObject, IFileSaver fileSaver)
        {
            var path = EditorUtility.SaveFilePanel("Select Folder", Application.dataPath, "monster", "prefab");
            if(path == string.Empty)
                return;
            fileSaver.Save(gameObject, path);
        }
    }
}
