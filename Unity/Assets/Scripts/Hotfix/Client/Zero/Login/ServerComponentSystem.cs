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
    }
}