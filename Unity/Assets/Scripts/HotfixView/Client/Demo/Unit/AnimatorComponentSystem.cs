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
            args.Unit.GetComponent<AnimatorComponent>()?.Play(HumanoidAnimations.Run);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class MoveStop_Animator : AEvent<Scene, MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        {
            args.Unit.GetComponent<AnimatorComponent>()?.Play(HumanoidAnimations.Idle);

            await ETTask.CompletedTask;
        }
    }

    [EntitySystemOf(typeof(AnimatorComponent))]
    [FriendOf(typeof(AnimatorComponent))]
    public static partial class AnimatorComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AnimatorComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this AnimatorComponent self)
        {
            self.AnimancerComponent = null;
        }

        public static void UpdateAnimData(this AnimatorComponent self, GameObject go)
        {
            self.AnimancerComponent = null;

            self.AnimancerComponent = go.GetComponent<AnimancerComponent>();
            if (self.AnimancerComponent == null)
            {
                Log.Error("对象未添加 mono脚本 AnimancerComponent！！！");
                return;
            }

            self.Play(HumanoidAnimations.Idle);
        }

        public static void Play(this AnimatorComponent self, StringReference stringReference)
        {
            self.AnimancerComponent.TryPlay(stringReference);
        }
    }
}