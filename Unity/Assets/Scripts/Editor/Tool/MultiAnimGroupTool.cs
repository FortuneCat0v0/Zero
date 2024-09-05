using System;
using System.Collections.Generic;
using System.IO;
using Animancer;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace ET
{
    public class MultiAnimGroupTool : EditorWindow
    {
        private string prefabFolderPath = "Assets/Bundles/Unit";
        private string assetBaseFolderPath = "Assets/Res/AnimGroup";

        [MenuItem("Tools/Animancer/Generate Multi AnimGroup")]
        private static void ShowWindow()
        {
            var window = GetWindow<MultiAnimGroupTool>("Generate Multi AnimGroup");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Prefab Folder Path", GUILayout.Width(150));
            prefabFolderPath = EditorGUILayout.TextField(prefabFolderPath, GUILayout.Width(300));

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", prefabFolderPath, "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        prefabFolderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Debug.LogError("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Asset Base Folder Path", GUILayout.Width(150));
            assetBaseFolderPath = EditorGUILayout.TextField(assetBaseFolderPath, GUILayout.Width(300));

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", assetBaseFolderPath, "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        assetBaseFolderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Debug.LogError("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Generate Animation State Data"))
            {
                GenerateOrUpdateAnimationStateData();
            }
        }

        private void GenerateOrUpdateAnimationStateData()
        {
            if (string.IsNullOrEmpty(prefabFolderPath) || !prefabFolderPath.StartsWith("Assets"))
            {
                Log.Error("请输入正确的文件路径");
                return;
            }

            if (string.IsNullOrEmpty(assetBaseFolderPath) || !assetBaseFolderPath.StartsWith("Assets"))
            {
                Log.Error("请输入正确的文件路径");
                return;
            }

            string[] prefabPaths = Directory.GetFiles(prefabFolderPath, "*.prefab", SearchOption.AllDirectories);

            foreach (string prefabPath in prefabPaths)
            {
                if (prefabPath.Contains("Unit\\Parts\\"))
                {
                    continue;
                }

                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                Animator animator = prefab.GetComponent<Animator>();

                if (animator != null)
                {
                    AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;

                    if (animatorController != null)
                    {
                        string relativePath = Path.GetDirectoryName(prefabPath).Substring(prefabFolderPath.Length);
                        string assetFolderPath = (assetBaseFolderPath + relativePath).Replace('\\', '/');

                        if (!AssetDatabase.IsValidFolder(assetFolderPath))
                        {
                            string[] folders = assetFolderPath.Split('/');
                            string currentPath = "";
                            for (int i = 0; i < folders.Length; i++)
                            {
                                string folder = folders[i];
                                if (string.IsNullOrEmpty(folder)) continue;

                                if (i == 0)
                                {
                                    currentPath = folder;
                                }
                                else
                                {
                                    string parentPath = currentPath;
                                    currentPath = $"{parentPath}/{folder}";
                                    if (!AssetDatabase.IsValidFolder(currentPath))
                                    {
                                        AssetDatabase.CreateFolder(parentPath, folder);
                                    }
                                }
                            }
                        }

                        string assetName = animatorController.name;
                        string assetPath = Path.Combine(assetFolderPath, $"{assetName}.asset");

                        AnimGroup animGroup = AssetDatabase.LoadAssetAtPath<AnimGroup>(assetPath);

                        if (animGroup == null)
                        {
                            animGroup = ScriptableObject.CreateInstance<AnimGroup>();
                            AssetDatabase.CreateAsset(animGroup, assetPath);
                        }

                        var states = animatorController.layers[0].stateMachine.states;
                        animGroup.AnimInfos = new();

                        for (int i = 0; i < states.Length; i++)
                        {
                            var state = states[i].state;
                            var motion = state.motion;

                            if (motion is BlendTree blendTree)
                            {
                                var blendTreeClips = GetAnimationClipsFromBlendTree(blendTree);
                                foreach (var clip in blendTreeClips)
                                {
                                    animGroup.AnimInfos.Add(new AnimInfo()
                                    {
                                        StateName = clip.name,
                                        AnimationClip = clip
                                    });
                                }
                            }
                            else
                            {
                                animGroup.AnimInfos.Add(new AnimInfo()
                                {
                                    StateName = state.name,
                                    AnimationClip = motion as AnimationClip,
                                    Speed = state.speed,
                                    NextStateName = GetNextStateName(state)
                                });
                            }
                        }

                        // 保存 ScriptableObject
                        EditorUtility.SetDirty(animGroup);
                        AssetDatabase.SaveAssets();

                        Log.Debug(prefabPath + " AnimGroup generated at " + assetPath);

                        // 添加组件和引用
                        AnimancerComponent animancerComponent = prefab.GetComponent<AnimancerComponent>();
                        if (animancerComponent == null)
                        {
                            prefab.AddComponent<AnimancerComponent>();
                        }

                        AnimData animData = prefab.GetComponent<AnimData>();
                        if (animData == null)
                        {
                            animData = prefab.AddComponent<AnimData>();
                        }

                        animData.AnimGroup = animGroup;
                        EditorUtility.SetDirty(prefab);
                        PrefabUtility.SavePrefabAsset(prefab);
                    }
                }
            }
        }

        private AnimationClip[] GetAnimationClipsFromBlendTree(BlendTree blendTree)
        {
            var clips = new List<AnimationClip>();
            ExtractClipsFromBlendTreeRecursive(blendTree, clips);
            return clips.ToArray();
        }

        private void ExtractClipsFromBlendTreeRecursive(BlendTree blendTree, List<AnimationClip> clips)
        {
            foreach (var child in blendTree.children)
            {
                if (child.motion is AnimationClip clip)
                {
                    clips.Add(clip);
                }
                else if (child.motion is BlendTree childBlendTree)
                {
                    ExtractClipsFromBlendTreeRecursive(childBlendTree, clips);
                }
            }
        }

        private string GetNextStateName(AnimatorState state)
        {
            foreach (var transition in state.transitions)
            {
                if (transition.conditions.Length == 0 && transition.hasExitTime)
                {
                    // 下一个状态是Exit
                    if (transition.destinationState == null)
                    {
                        continue;
                    }

                    return transition.destinationState.name;
                }
            }

            return null;
        }
    }
}