namespace ET.Server
{
    [FriendOf(typeof(MailCenterComponent))]
    [EntitySystemOf(typeof(MailCenterComponent))]
    public static partial class MailCenterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MailCenterComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MailCenterComponent self)
        {
        }
    }
}