using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ClientSlimeComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<Slime>> Slimes = new();
    }
}