using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(GameServerComponent))]
    [EntitySystemOf(typeof(GameServerComponent))]
    public static partial class GameServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameServerComponent self)
        {
            self.Load().Coroutine();
        }

        private static async ETTask Load(this GameServerComponent self)
        {
            List<GameServer> servers = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<GameServer>(d => true);

            // 若数据库中没有数据，从配置表中获取并存入数据库。实际商业游戏有后台配置
            if (servers == null || servers.Count <= 0)
            {
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.DataList;

                foreach (ServerInfoConfig info in serverInfoConfigs)
                {
                    GameServer newServer = self.AddChildWithId<GameServer>(info.Id);
                    newServer.ServerName = info.ServerName;
                    newServer.Status = (int)ServerStatus.Normal;
                    self.GameServers.Add(newServer);
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(newServer);
                }

                return;
            }

            foreach (GameServer server in servers)
            {
                self.AddChild(server);
                self.GameServers.Add(server);
            }

            await ETTask.CompletedTask;
        }
    }
}