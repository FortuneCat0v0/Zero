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
            self.Unit = GameObject.Find("/Global/Unit").transform;
            self.Effect = GameObject.Find("/Global/Effect").transform;
            self.Audio = GameObject.Find("/Global/Audio").transform;
            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
        }
    }
}