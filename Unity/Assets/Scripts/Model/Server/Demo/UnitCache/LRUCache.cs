using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(UnitCacheComponent))]
    public class LRUCache : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<LRUNode>> LRUNodeDic = new();
        public Dictionary<long, LinkedList<EntityRef<LRUNode>>> FrequencyDict = new();
        public int MinFrequency;
    }
}