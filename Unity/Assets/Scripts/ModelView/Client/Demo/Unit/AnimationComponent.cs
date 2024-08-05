using System.Collections.Generic;
using Animancer;

namespace ET.Client
{
    [ComponentOf]
    public class AnimationComponent : Entity, IAwake, IDestroy
    {
        public AnimancerComponent Animancer;
        public AnimGroup AnimGroup;
        public Dictionary<string, ClipTransition> ClipTransitions = new();
        public string CurrentAnimation { get; set; }
    }
}