namespace ET
{
    [FriendOf(typeof(Pet))]
    [EntitySystemOf(typeof(Pet))]
    public static partial class PetSystem
    {
        [EntitySystem]
        private static void Awake(this Pet self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Pet self)
        {
        }

        public static PetInfo ToMessage(this Pet self)
        {
            PetInfo petInfo = PetInfo.Create();
            petInfo.Id = self.Id;
            petInfo.ConfigId = self.ConfigId;

            return petInfo;
        }

        public static void FromMessage(this Pet self, PetInfo petInfo)
        {
            self.ConfigId = petInfo.ConfigId;
        }
    }
}