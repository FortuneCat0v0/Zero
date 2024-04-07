namespace ET
{
    [FriendOf(typeof(Quest))]
    [EntitySystemOf(typeof(Quest))]
    public static partial class QuestSystem
    {
        [EntitySystem]
        private static void Awake(this Quest self)
        {
        }
    }
}