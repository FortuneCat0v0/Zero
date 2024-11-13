using System.Collections.Generic;

namespace ET.Client
{
    [ChildOf(typeof(ClientKnapsackComponent))]
    public class ClientKnapsackContainerComponent : Entity, IAwake<int>, IDestroy
    {
        public int KnapsackContainerType { get; set; }

        public Dictionary<long, EntityRef<Item>> Items = new();
    }
}