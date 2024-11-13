using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ClientKnapsackComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, EntityRef<ClientKnapsackContainerComponent>> ContainerInfoDic = new();
    }
}