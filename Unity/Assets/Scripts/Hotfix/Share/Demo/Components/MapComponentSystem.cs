namespace ET
{
    [FriendOf(typeof(MapComponent))]
    [EntitySystemOf(typeof(MapComponent))]
    public static partial class MapComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MapComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MapComponent self)
        {
        }
    }
}