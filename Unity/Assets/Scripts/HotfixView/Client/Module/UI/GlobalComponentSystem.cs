using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(GlobalComponent))]
    [EntitySystemOf(typeof(GlobalComponent))]
    public static partial class GlobalComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GlobalComponent self)
        {
            self.Global = GameObject.Find("/Global").transform;
            self.MainCamera = GameObject.Find("/Global/MainCamera").transform;
            self.Mask = GameObject.Find("/Global/Mask");
            self.UICamera = GameObject.Find("/Global/YIUIRoot/YIUICanvasRoot/YIUICamera").transform;
            self.YIUICanvasRoot = GameObject.Find("/Global/YIUIRoot/YIUICanvasRoot").transform;
            self.UnitRoot = GameObject.Find("/Global/UnitRoot").transform;
            self.EffectRoot = GameObject.Find("/Global/EffectRoot").transform;
            self.AudioRoot = GameObject.Find("/Global/AudioRoot").transform;
            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
        }
    }
}