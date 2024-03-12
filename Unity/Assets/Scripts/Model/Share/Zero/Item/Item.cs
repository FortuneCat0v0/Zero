using System.Collections.Generic;

namespace ET
{
    [ChildOf]
    public class Item : Entity, IAwake, IAwake<int>, ISerializeToEntity
    {
        public int ConfigId { get; set; }
        public List<long> AttributeEntryIds { get; set; } = new();
    }
}