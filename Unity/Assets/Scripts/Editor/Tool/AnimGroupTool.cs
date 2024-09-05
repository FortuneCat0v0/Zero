using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Animancer
{
    public class AnimGroupTool : EditorWindow
    {
        private AnimatorController animatorController;
        private string assetName = "New AnimGroup";
        private string folderPath = "Assets/Res/AnimGroup";

        [MenuItem("Tools/Animancer/Generate AnimGroup")]
        private static void ShowWindow()
        {
            var window = GetWindow<AnimGroupTool>("Generate AnimGroup");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            animatorController =
                    (AnimatorController)EditorGUILayout.ObjectField("Animator Controller", animatorController, typeof(AnimatorController), false);
            if (EditorGUI.EndChangeCheck() && animatorController != null)
            {
                assetName = animatorController.name;
            }

            assetName = EditorGUILayout.TextField("Asset Name", assetName);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Folder Path", GUILayout.Width(80));
            folderPath = EditorGUILayout.TextField(folderPath);

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", "Assets", "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        folderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Debug.LogError("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Generate"))
            {
                this.GenerateOrUpdateAnimGroup();
            }
        }

        private void GenerateOrUpdateAnimGroup()
        {
            if (this.animatorController == null)
            {
                Debug.LogError("请选择AnimatorController");
                return;
            }

            if (string.IsNullOrEmpty(this.assetName))
            {
                Debug.LogError("请输入生成Asset的名字");
                return;
            }

            if (string.IsNullOrEmpty(folderPath) || !folderPath.StartsWith("Assets"))
            {
                Debug.LogError("请输入正确的文件路径");
                return;
            }

            string path = $"{this.folderPath}/{this.assetName}.asset";
            AnimGroup animGroup = AssetDatabase.LoadAssetAtPath<AnimGroup>(path);

            if (animGroup == null)
            {
                // 如果不存在，则创建一个新的 ScriptableObject
                animGroup = ScriptableObject.CreateInstance<AnimGroup>();
                AssetDatabase.CreateAsset(animGroup, path);
            }

            // 更新并填充 ScriptableObject
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

            Debug.Log("AnimGroup generated at " + path);
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