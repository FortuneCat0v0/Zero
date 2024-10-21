using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(LRUCache))]
    [FriendOf(typeof(LRUNode))]
    [EntitySystemOf(typeof(LRUCache))]
    public static partial class LRUCacheSystem
    {
        [EntitySystem]
        private static void Awake(this LRUCache self)
        {
            self.FrequencyDict.Add(0, new());
            self.MinFrequency = 0;
        }

        [EntitySystem]
        private static void Destroy(this LRUCache self)
        {
            self.LRUNodeDic.Clear();
            self.FrequencyDict.Clear();
            self.MinFrequency = 0;
        }

        public static void Call(this LRUCache self, long unitId)
        {
            EntityRef<LRUNode> nodeRef;
            LRUNode n;
            if (self.LRUNodeDic.TryGetValue(unitId, out nodeRef))
            {
                n = nodeRef;
                self.FrequencyDict[n.Frequency].Remove(n);
                n.Frequency++;
                if (!self.FrequencyDict.ContainsKey(n.Frequency))
                {
                    self.FrequencyDict.Add(n.Frequency, new());
                }

                self.FrequencyDict[n.Frequency].AddLast(n);

                if (self.FrequencyDict[self.MinFrequency].Count == 0)
                {
                    self.MinFrequency = n.Frequency;
                }

                return;
            }

            n = self.AddChild<LRUNode, long>(unitId);
            n.Frequency = 0;

            self.FrequencyDict[0].AddLast(n);
            self.MinFrequency = 0;
            self.LRUNodeDic[unitId] = n;

            if (self.LRUNodeDic.Count >= 3000)
            {
                LRUNode fn = self.FrequencyDict[self.MinFrequency].First.Value;
                long uId = fn.Key;
                self.FrequencyDict[self.MinFrequency].RemoveFirst();
                self.LRUNodeDic.Remove(uId);
                fn.Dispose();

                EventSystem.Instance.Invoke((long)SceneType.UnitCache, new LRUUnitCacheDelete() { LruCache = self, Key = uId });
            }
        }
    }
}