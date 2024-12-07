namespace ET.Server
{
    [FriendOf(typeof(MailUnitsComponent))]
    [EntitySystemOf(typeof(MailUnitsComponent))]
    public static partial class MailUnitsComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MailUnitsComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MailUnitsComponent self)
        {
        }
    }
}