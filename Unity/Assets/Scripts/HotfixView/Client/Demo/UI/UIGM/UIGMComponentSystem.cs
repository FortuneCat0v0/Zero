namespace ET.Client
{
    [FriendOf(typeof(UIGMComponent))]
    [EntitySystemOf(typeof(UIGMComponent))]
    public static partial class UIGMComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIGMComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
        }
    }
}