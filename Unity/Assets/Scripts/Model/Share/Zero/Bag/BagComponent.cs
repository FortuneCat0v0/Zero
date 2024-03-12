using System.Collections.Generic;

namespace ET
{
    [ComponentOf]
    public class BagComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public List<long> ItemIds = new();
    }
}