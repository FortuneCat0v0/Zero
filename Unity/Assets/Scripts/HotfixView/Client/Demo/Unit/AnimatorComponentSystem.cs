﻿using System;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MoveStart_Animator : AEvent<Scene, MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        {
            Log.Warning("start");

            args.Unit.GetComponent<AnimatorComponent>()?.SetFloatValue("yVelocity", 1f);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class MoveStop_Animator : AEvent<Scene, MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        {
            Log.Warning("stop");

            args.Unit.GetComponent<AnimatorComponent>()?.SetFloatValue("yVelocity", 0);

            await ETTask.CompletedTask;
        }
    }

    [EntitySystemOf(typeof(AnimatorComponent))]
    [FriendOf(typeof(AnimatorComponent))]
    public static partial class AnimatorComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AnimatorComponent self, GameObject gameObject)
        {
            Animator animator = gameObject.GetComponent<Animator>();

            if (animator == null)
            {
                return;
            }

            if (animator.runtimeAnimatorController == null)
            {
                return;
            }

            if (animator.runtimeAnimatorController.animationClips == null)
            {
                return;
            }

            self.Animator = animator;
            foreach (AnimationClip animationClip in animator.runtimeAnimatorController.animationClips)
            {
                self.AnimationClips[animationClip.name] = animationClip;
            }

            foreach (AnimatorControllerParameter animatorControllerParameter in animator.parameters)
            {
                self.Parameter.Add(animatorControllerParameter.name);
            }
        }

        [EntitySystem]
        private static void Destroy(this AnimatorComponent self)
        {
            self.AnimationClips = null;
            self.Parameter = null;
            self.Animator = null;
        }

        [EntitySystem]
        private static void Update(this AnimatorComponent self)
        {
            if (self.IsStop)
            {
                return;
            }

            // if (self.MotionType == MotionType.None)
            // {
            //     return;
            // }

            try
            {
                // self.Animator.SetFloat("MotionSpeed", self.MontionSpeed);

                // self.Animator.SetTrigger(self.MotionType.ToString());

                self.MontionSpeed = 1;
                self.MotionType = MotionType.None;
            }
            catch (Exception ex)
            {
                throw new Exception($"动作播放失败: {self.MotionType}", ex);
            }
        }

        public static bool HasParameter(this AnimatorComponent self, string parameter)
        {
            return self.Parameter.Contains(parameter);
        }

        public static void PlayInTime(this AnimatorComponent self, MotionType motionType, float time)
        {
            AnimationClip animationClip;
            if (!self.AnimationClips.TryGetValue(motionType.ToString(), out animationClip))
            {
                throw new Exception($"找不到该动作: {motionType}");
            }

            float motionSpeed = animationClip.length / time;
            if (motionSpeed < 0.01f || motionSpeed > 1000f)
            {
                Log.Error($"motionSpeed数值异常, {motionSpeed}, 此动作跳过");
                return;
            }

            self.MotionType = motionType;
            self.MontionSpeed = motionSpeed;
        }

        public static void Play(this AnimatorComponent self, MotionType motionType, float motionSpeed = 1f)
        {
            if (!self.HasParameter(motionType.ToString()))
            {
                return;
            }

            self.MotionType = motionType;
            self.MontionSpeed = motionSpeed;
        }

        public static float AnimationTime(this AnimatorComponent self, MotionType motionType)
        {
            AnimationClip animationClip;
            if (!self.AnimationClips.TryGetValue(motionType.ToString(), out animationClip))
            {
                throw new Exception($"找不到该动作: {motionType}");
            }

            return animationClip.length;
        }

        public static void PauseAnimator(this AnimatorComponent self)
        {
            if (self.IsStop)
            {
                return;
            }

            self.IsStop = true;

            if (self.Animator == null)
            {
                return;
            }

            self.StopSpeed = self.Animator.speed;
            self.Animator.speed = 0;
        }

        public static void RunAnimator(this AnimatorComponent self)
        {
            if (!self.IsStop)
            {
                return;
            }

            self.IsStop = false;

            if (self.Animator == null)
            {
                return;
            }

            self.Animator.speed = self.StopSpeed;
        }

        public static void SetBoolValue(this AnimatorComponent self, string name, bool state)
        {
            if (!self.HasParameter(name))
            {
                return;
            }

            self.Animator.SetBool(name, state);
        }

        public static void SetFloatValue(this AnimatorComponent self, string name, float state)
        {
            if (!self.HasParameter(name))
            {
                return;
            }

            self.Animator.SetFloat(name, state);
        }

        public static void SetIntValue(this AnimatorComponent self, string name, int value)
        {
            if (!self.HasParameter(name))
            {
                return;
            }

            self.Animator.SetInteger(name, value);
        }

        public static void SetTrigger(this AnimatorComponent self, string name)
        {
            if (!self.HasParameter(name))
            {
                return;
            }

            self.Animator.SetTrigger(name);
        }

        public static void SetAnimatorSpeed(this AnimatorComponent self, float speed)
        {
            self.StopSpeed = self.Animator.speed;
            self.Animator.speed = speed;
        }

        public static void ResetAnimatorSpeed(this AnimatorComponent self)
        {
            self.Animator.speed = self.StopSpeed;
        }
    }
}