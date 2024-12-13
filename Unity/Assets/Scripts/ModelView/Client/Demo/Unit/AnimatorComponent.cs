using Animancer;

namespace ET.Client
{
    public static class HumanoidAnimations
    {
        [StaticField]
        public static readonly StringReference Idle = "Idle";

        [StaticField]
        public static readonly StringReference Run = "Run";
    }

    [ComponentOf(typeof(Unit))]
    public class AnimatorComponent : Entity, IAwake, IDestroy
    {
        public AnimancerComponent AnimancerComponent;
    }
}