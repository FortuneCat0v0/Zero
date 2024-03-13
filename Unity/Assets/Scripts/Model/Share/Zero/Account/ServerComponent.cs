using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class ServerComponent : Entity, IAwake
    {
        public List<long> ServerIds = new();

        public int CurrentServerId { get; set; }
    }
}