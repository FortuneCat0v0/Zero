namespace ET
{
    [FriendOf(typeof(SkillComponent))]
    [FriendOf(typeof(BuffComponent))]
    [EntitySystemOf(typeof(BuffComponent))]
    public static partial class BuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this BuffComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BuffComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                Buff buff = entity as Buff;
                self.BuffDict.Add(buff.BuffConfigId, buff);
            }
        }

        public static bool AddBuff(this BuffComponent self, int buffConfigId)
        {
            if (!self.BuffDict.ContainsKey(buffConfigId))
            {
                BuffConfig buffConfig = BuffConfigCategory.Instance.Get(buffConfigId);
                if (buffConfig == null)
                {
                    Log.Error($"配置表不存在buff {buffConfigId}");
                    return false;
                }

                Buff buff = self.AddChild<Buff, int>(buffConfigId);
                buff.LayerCount = 1;

                self.BuffDict.Add(buffConfigId, buff);

                return true;
            }

            Log.Error($"已经存在buff configId:{buffConfigId}");
            return false;
        }

        public static bool RemoveBuff(this BuffComponent self, int buffConfigId)
        {
            if (!self.BuffDict.ContainsKey(buffConfigId))
            {
                return false;
            }

            Buff buff = self.BuffDict[buffConfigId];
            self.BuffDict.Remove(buffConfigId);
            buff.Dispose();
            return true;
        }
    }
}