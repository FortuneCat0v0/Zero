using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class GameServerComponent : Entity, IAwake
    {
        public List<EntityRef<GameServer>> GameServers = new();
    }
}