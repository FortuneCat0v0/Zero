using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(ServerComponent))]
    [EntitySystemOf(typeof(ServerComponent))]
    public static partial class ServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ServerComponent self)
        {
        }

        public static bool Add(this ServerComponent self, long id)
        {
            if (self.ServerIds.Contains(id))
            {
                return false;
            }

            self.ServerIds.Add(id);
            return true;
        }

        public static GameServer Get(this ServerComponent self, long id)
        {
            if (!self.ServerIds.Contains(id))
            {
                return null;
            }

            return self.GetChild<GameServer>(id);
        }

        public static List<GameServer> GetAll(this ServerComponent self)
        {
            return self.Children.Values.Select(entity => entity as GameServer).ToList();
        }
    }
}