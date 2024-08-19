namespace ET.Client
{
    [Event(SceneType.Current)]
    public class PlayEffect_PlayView : AEvent<Scene, PlayEffect>
    {
        protected override async ETTask Run(Scene scene, PlayEffect args)
        {
            args.Unit.GetComponent<EffectComponent>().PlayEffect(args.EffectId, args.EffectData);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    public class RemoveEffect_RemoveView : AEvent<Scene, RemoveEffect>
    {
        protected override async ETTask Run(Scene scene, RemoveEffect args)
        {
            args.Unit.GetComponent<EffectComponent>().RemoveEffect(args.EffectId);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(EffectComponent))]
    [EntitySystemOf(typeof(EffectComponent))]
    public static partial class EffectComponentSystem
    {
        [EntitySystem]
        private static void Awake(this EffectComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this EffectComponent self)
        {
        }

        public static void PlayEffect(this EffectComponent self, long effectId, EffectData effectData)
        {
            Effect effect = self.AddChildWithId<Effect, EffectData>(effectId, effectData);
        }

        public static void RemoveEffect(this EffectComponent self, long effectId)
        {
            // if (self.Children.ContainsKey(effectId))
            // {
            //     Effect effect = self.Children[effectId] as Effect;
            //     effect.Dispose();
            // }
        }
    }
}