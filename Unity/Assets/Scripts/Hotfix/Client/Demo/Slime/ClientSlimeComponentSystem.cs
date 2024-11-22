namespace ET.Client
{
    [FriendOf(typeof(ClientSlimeComponent))]
    [EntitySystemOf(typeof(ClientSlimeComponent))]
    public static partial class ClientSlimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSlimeComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientSlimeComponent self)
        {
            self.Slimes.Clear();
            self.Slimes = null;
        }

        public static void AddSlimeFromMessage(this ClientSlimeComponent self, SlimeInfo slimeInfo)
        {
            Slime slime = self.AddChildWithId<Slime>(slimeInfo.Id);
            slime.FromMessage(slimeInfo);
            self.Slimes.Add(slime.Id, slime);
        }

        public static void RemoveSlimeById(this ClientSlimeComponent self, long slimeId)
        {
            if (!self.Slimes.TryGetValue(slimeId, out EntityRef<Slime> slimeRef))
            {
                Log.Error($"slimeId:{slimeId} not found");
                return;
            }

            Slime slime = slimeRef;
            self.Slimes.Remove(slimeId);
            slime?.Dispose();
        }

        public static void UpdateSlime(this ClientSlimeComponent self, SlimeInfo slimeInfo)
        {
            if (!self.Slimes.TryGetValue(slimeInfo.Id, out EntityRef<Slime> slimeRef))
            {
                Log.Error($"slimeId:{slimeInfo.Id} not found");
                return;
            }

            Slime slime = slimeRef;
            slime.FromMessage(slimeInfo);
        }

        public static void Clear(this ClientSlimeComponent self)
        {
            foreach (Slime slime in self.Slimes.Values)
            {
                slime?.Dispose();
            }

            self.Slimes.Clear();
        }
    }
}