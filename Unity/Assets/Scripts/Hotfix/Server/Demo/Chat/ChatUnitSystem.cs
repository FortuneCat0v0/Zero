namespace ET.Server
{
    [FriendOf(typeof(ChatUnit))]
    [EntitySystemOf(typeof(ChatUnit))]
    public static partial class ChatUnitSystem
    {
        [EntitySystem]
        private static void Awake(this ChatUnit self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ChatUnit self)
        {
            self.Name = null;
        }
    }
}