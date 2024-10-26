namespace ET.Client
{
    [FriendOf(typeof(ChatComponent))]
    [EntitySystemOf(typeof(ChatComponent))]
    public static partial class ChatComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ChatComponent self)
        {
        }
    }
}