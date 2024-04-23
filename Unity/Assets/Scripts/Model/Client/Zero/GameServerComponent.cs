using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GameServerComponent : Entity, IAwake
    {
        public List<EntityRef<GameServer>> GameServers = new();
        public int CurrentServerId { get; set; }
    }
}