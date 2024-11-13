namespace ET
{
    [FriendOf(typeof(Slime))]
    [EntitySystemOf(typeof(Slime))]
    public static partial class SlimeSystem
    {
        [EntitySystem]
        private static void Awake(this Slime self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Slime self)
        {
        }

        public static SlimeInfo ToMessage(this Slime self)
        {
            SlimeInfo slimeInfo = SlimeInfo.Create();
            slimeInfo.Id = self.Id;
            slimeInfo.Name = self.Name;

            return slimeInfo;
        }

        public static void FromMessage(this Slime self, SlimeInfo slimeInfo)
        {
            self.Name = slimeInfo.Name;
        }
    }
}