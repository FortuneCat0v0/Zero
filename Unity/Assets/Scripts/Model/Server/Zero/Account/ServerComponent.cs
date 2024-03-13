using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class ServerComponent : Entity, IAwake
    {
        public List<long> ServerIds = new();
    }
}