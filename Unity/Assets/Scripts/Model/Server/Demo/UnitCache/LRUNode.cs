namespace ET.Server
{
    [ChildOf(typeof(LRUCache))]
    public class LRUNode : Entity, IAwake<long>, IDestroy
    {
        public long Key;
        public int Frequency;
    }
}