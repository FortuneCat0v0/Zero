using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ServerComponent : Entity, IAwake
    {
        public List<EntityRef<GameServer>> GameServers = new();
        public int CurrentServerId { get; set; }
    }
}