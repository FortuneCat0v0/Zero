using System;
using Animancer;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MoveStart_Animator : AEvent<Scene, MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        {
            args.Unit.GetComponent<AnimationComponent>()?.Play("Crawl_Forward");

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class MoveStop_Animator : AEvent<Scene, MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        {
            args.Unit.GetComponent<AnimationComponent>()?.Play("Idle");

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(AnimationComponent))]
    [EntitySystemOf(typeof(AnimationComponent))]
    public static partial class AnimationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AnimationComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
            self.Animancer = null;
            self.AnimGroup = null;
            self.CurrentAnimation = null;
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go)
        {
            self.Animancer = null;
            self.AnimGroup = null;
            self.CurrentAnimation = null;

            // 使用Animancer的话Animator不要添加Controller
            Animator animator = go.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = null;

            self.Animancer = go.GetComponentInChildren<AnimancerComponent>();
            if (self.Animancer == null)
            {
                Log.Error("对象未添加 mono脚本 AnimancerComponent！！！");
                return;
            }

            AnimData animData = go.GetComponentInChildren<AnimData>();
            if (animData == null)
            {
                Log.Error("对象未添加 mono脚本 AnimData！！！");
                return;
            }

            if (animData.AnimGroup == null)
            {
                Log.Error("mono脚本 AnimData 没有添加AnimGroup！！！");
                return;
            }

            if (animData.AnimGroup.AnimInfos.Count == 0)
            {
                Log.Error($"{animData.AnimGroup.name} 没有添加动画片段！！！");

                return;
            }

            self.AnimGroup = animData.AnimGroup;

            self.Play("Idle");
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="fadeMode">
        /// FadeMode.FixedDuration 一般用于等待、行走等循环动画 或 播放期间不会重新播放。此模式下，若想重复一个动作，而该动作仍在运行时，不会有变化。
        /// FadeMode.FromStart 一般用于攻击动画。当想要重复一个动作，而该动作仍在运行时使用。如平A动画未结束又重新平A。
        /// </param>
        /// <param name="speed"></param>
        public static void Play(this AnimationComponent self, string name, FadeMode fadeMode = FadeMode.FixedDuration, float speed = 0)
        {
            AnimInfo animInfo = null;
            foreach (AnimInfo a in self.AnimGroup.AnimInfos)
            {
                if (a.StateName == name)
                {
                    animInfo = a;
                    break;
                }
            }

            if (animInfo == null)
            {
                Log.Error($"动画 {name} 未加载");

                return;
            }

            self.CurrentAnimation = name;
            self.Animancer.Playable.Speed = speed != 0 ? speed : animInfo.Speed;

            Log.Debug($"播放动画 {name}");

            if (!string.IsNullOrEmpty(animInfo.NextStateName))
            {
                self.Animancer.Play(animInfo.AnimationClip, 0.25f, fadeMode).Events.OnEnd = () =>
                {
                    Log.Debug($"{animInfo.StateName} 播放完毕,自动切换为 {animInfo.NextStateName}");
                    self.Play(animInfo.NextStateName);
                };
            }
            else
            {
                self.Animancer.Play(animInfo.AnimationClip, 0.25f, fadeMode);
            }
        }
    }
}