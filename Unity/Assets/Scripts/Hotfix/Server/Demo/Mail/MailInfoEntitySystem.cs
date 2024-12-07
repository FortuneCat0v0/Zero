namespace ET.Server
{
    [FriendOf(typeof(MailInfoEntity))]
    [EntitySystemOf(typeof(MailInfoEntity))]
    public static partial class MailInfoEntitySystem
    {
        [EntitySystem]
        private static void Awake(this MailInfoEntity self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MailInfoEntity self)
        {
        }
    }
}