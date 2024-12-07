namespace ET.Server
{
    [FriendOf(typeof(MailUnit))]
    [EntitySystemOf(typeof(MailUnit))]
    public static partial class MailUnitSystem
    {
        [EntitySystem]
        private static void Awake(this MailUnit self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MailUnit self)
        {
        }
    }
}