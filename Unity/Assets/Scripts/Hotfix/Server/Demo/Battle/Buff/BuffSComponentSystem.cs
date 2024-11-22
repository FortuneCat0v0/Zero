namespace ET.Server
{
    [FriendOf(typeof(SkillComponent))]
    [FriendOf(typeof(BuffSComponent))]
    [EntitySystemOf(typeof(BuffSComponent))]
    public static partial class BuffSComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BuffSComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this BuffSComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BuffSComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                BuffS buffS = entity as BuffS;
                self.BuffDict.Add(buffS.BuffConfigId, buffS);
            }
        }

        public static bool AddBuff(this BuffSComponent self, int buffConfigId)
        {
            if (!self.BuffDict.ContainsKey(buffConfigId))
            {
                BuffConfig buffConfig = BuffConfigCategory.Instance.Get(buffConfigId);
                if (buffConfig == null)
                {
                    Log.Error($"配置表不存在buff {buffConfigId}");
                    return false;
                }

                BuffS buffS = self.AddChild<BuffS, int>(buffConfigId);
                buffS.LayerCount = 1;

                self.BuffDict.Add(buffConfigId, buffS);

                return true;
            }

            Log.Error($"已经存在buff configId:{buffConfigId}");
            return false;
        }

        public static bool RemoveBuff(this BuffSComponent self, int buffConfigId)
        {
            if (!self.BuffDict.ContainsKey(buffConfigId))
            {
                return false;
            }

            BuffS buffS = self.BuffDict[buffConfigId];
            self.BuffDict.Remove(buffConfigId);
            buffS.Dispose();
            return true;
        }
    }
}