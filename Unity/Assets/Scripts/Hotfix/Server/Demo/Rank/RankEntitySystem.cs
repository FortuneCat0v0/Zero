namespace ET.Server
{
    [FriendOf(typeof(RankEntity))]
    [EntitySystemOf(typeof(RankEntity))]
    public static partial class RankEntitySystem
    {
        [EntitySystem]
        private static void Awake(this RankEntity self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RankEntity self)
        {
        }
    }
}