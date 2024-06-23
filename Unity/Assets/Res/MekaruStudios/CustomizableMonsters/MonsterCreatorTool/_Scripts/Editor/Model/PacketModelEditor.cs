using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [CustomEditor(typeof(PacketModel))]
    public class PacketModelEditor : Editor
    {
        SerializedProperty _selectedEditorIndexProperty;
        SerializedProperty _unitsProperty;

        void OnEnable()
        {
            _selectedEditorIndexProperty = serializedObject.FindProperty("_selectedEditorIndex");
            _unitsProperty = serializedObject.FindProperty("_units");
            Debug.Log(_unitsProperty);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();
            var currentIndex = _selectedEditorIndexProperty.intValue;
            var editorTypeNames = CustomizationEditorManager.CustomizationEditorTypes
                .Select(type => type.Name)
                .ToArray();
            var newSelectedIndex = EditorGUILayout.Popup("Customization Editor", currentIndex, editorTypeNames);
            _selectedEditorIndexProperty.intValue = newSelectedIndex;
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Find Monster Unit Models, in current/subfolders"))
            {
                serializedObject.Update();
                SetMonsterUnitModelsInCurrentFolder();
                serializedObject.ApplyModifiedProperties();
            }

        }

        void SetMonsterUnitModelsInCurrentFolder()
        {
            var currentAssetPath = AssetDatabase.GetAssetPath((PacketModel)target);
            var guids = GetMonsterUnitModelGuidsInGivenFolderAndSubfolders(currentAssetPath);
            var loadedUnitModels = LoadUnitModelsFormGuids(guids);

            _unitsProperty.ClearArray();
            for (var i = 0; i < loadedUnitModels.Count; i++)
            {
                var unitModel = loadedUnitModels[i];
                _unitsProperty.InsertArrayElementAtIndex(i);
                var elementProperty =_unitsProperty.GetArrayElementAtIndex(i);
                elementProperty.objectReferenceValue = unitModel;
            }

#if UNITY_EDITOR
            Debug.Log($"<color=#00FF00>{loadedUnitModels.Count}</color> unit model found and assigned.");
#endif
        }
        static List<UnitModel> LoadUnitModelsFormGuids(IEnumerable<string> guids)
        {
            var loadedUnitModels = guids
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<UnitModel>)
                .Where(unitModel => unitModel != null).ToList();
            return loadedUnitModels;
        }
        static IEnumerable<string> GetMonsterUnitModelGuidsInGivenFolderAndSubfolders(string currentAssetPath)
        {
            var guids =
                AssetDatabase.FindAssets($"t:{nameof(UnitModel)}", new[]
                {
                    Path.GetDirectoryName(currentAssetPath)
                });
            return guids;
        }
    }
}
