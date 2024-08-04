using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ET
{
    [Serializable]
    public class MotionTransition : ClipTransition
    {
        [SerializeField, Tooltip("Should Root Motion be enabled when this animation plays?")]
        private bool _ApplyRootMotion;

        public string StateName;

        public override void Apply(AnimancerState state)
        {
            base.Apply(state);
            state.Root.Component.Animator.applyRootMotion = _ApplyRootMotion;
        }
    }

    /// <summary>
    /// 类似AnimationController一样，保存一个动画组，方便一键修改应用到全部使用的对象
    /// </summary>
    [CreateAssetMenu(menuName = Strings.MenuPrefix + "AnimGroup", order = Strings.AssetMenuOrder + 1)]
    public class AnimGroup : ScriptableObject
    {
        public List<MotionTransition> Animations;
    }
}