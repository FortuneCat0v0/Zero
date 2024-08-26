namespace ET.Client
{
    [FriendOf(typeof(UIFlyTipComponent))]
    [EntitySystemOf(typeof(UIFlyTipComponent))]
    public static partial class UIFlyTipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIFlyTipComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
        }
    }
}