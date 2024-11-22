namespace ET.Server
{
    [FriendOf(typeof(SlimeComponent))]
    [EntitySystemOf(typeof(SlimeComponent))]
    public static partial class SlimeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SlimeComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SlimeComponent self)
        {
            self.Slimes.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this SlimeComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                if (entity is Slime slime)
                {
                    self.Slimes.Add(slime.Id, slime);
                }
            }
        }

        public static void GetSlimes(this SlimeComponent self, ListComponent<Slime> slimeList)
        {
            foreach (Slime slime in self.Slimes.Values)
            {
                slimeList.Add(slime);
            }
        }

        public static Slime GetSlime(this SlimeComponent self, long itemId)
        {
            self.Slimes.TryGetValue(itemId, out EntityRef<Slime> slimeRef);
            return slimeRef;
        }

        public static void AddSlime(this SlimeComponent self, Slime slime)
        {
            if (slime.Parent != self)
            {
                self.AddChild(slime);
            }

            if (self.Slimes.ContainsKey(slime.Id))
            {
                return;
            }

            self.Slimes.Add(slime.Id, slime);
            SlimeNoticeHelper.SyncSlimeInfo(self.Parent.GetParent<Unit>(), slime, SlimeOpType.Add);
        }

        public static bool RemoveSlime(this SlimeComponent self, long slimeId)
        {
            if (!self.Slimes.TryGetValue(slimeId, out EntityRef<Slime> slimeRef))
            {
                return false;
            }

            Slime slime = slimeRef;
            self.Slimes.Remove(slimeId);
            SlimeNoticeHelper.SyncSlimeInfo(self.Parent.GetParent<Unit>(), slime, SlimeOpType.Remove);
            slime?.Dispose();

            return true;
        }
    }
}