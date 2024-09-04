using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
    [Serializable]
    public class AnimInfo
    {
        public string StateName;
        public AnimationClip AnimationClip;
        public string NextStateName;
    }

    /// <summary>
    /// 类似AnimationController一样，保存一个动画组，方便一键修改应用到全部使用的对象
    /// </summary>
    [CreateAssetMenu(menuName = Strings.MenuPrefix + "AnimGroup", order = Strings.AssetMenuOrder + 1)]
    public class AnimGroup : ScriptableObject
    {
        public List<AnimInfo> AnimInfos;
    }
}