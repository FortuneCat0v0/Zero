using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public enum MotionType
    {
        None,
        Idle,
        Run,
    }

    [ComponentOf]
    public class AnimatorComponent : Entity, IAwake<GameObject>, IUpdate, IDestroy
    {
        public Dictionary<string, AnimationClip> AnimationClips = new();
        public HashSet<string> Parameter = new();

        public MotionType MotionType;
        public float MontionSpeed { get; set; }
        public bool IsStop;
        public float StopSpeed;
        public Animator Animator;
    }
}