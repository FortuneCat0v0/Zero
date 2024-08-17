namespace ET.Client
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(GameServerComponent))]
    [EntitySystemOf(typeof(GameServerComponent))]
    public static partial class GameServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameServerComponent self)
        {
        }
    }
}