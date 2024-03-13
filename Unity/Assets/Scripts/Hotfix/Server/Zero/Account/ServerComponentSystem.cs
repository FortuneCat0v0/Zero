using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(ServerComponent))]
    [EntitySystemOf(typeof(ServerComponent))]
    public static partial class ServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ServerComponent self)
        {
            self.Load().Coroutine();
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

        private static async ETTask Load(this ServerComponent self)
        {
            List<GameServer> servers = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<GameServer>(d => true);

            //若数据库中没有数据，从配置表中获取并存入数据库。实际商业游戏有后台配置
            if (servers == null || servers.Count <= 0)
            {
                self.ServerIds.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();

                foreach (ServerInfoConfig info in serverInfoConfigs.Values)
                {
                    GameServer newServer = self.AddChildWithId<GameServer>(info.Id);
                    newServer.ServerName = info.ServerName;
                    newServer.Status = (int)ServerStatus.Normal;
                    self.Add(newServer.Id);
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(newServer);
                }

                return;
            }

            self.ServerIds.Clear();

            foreach (GameServer serverInfo in servers)
            {
                self.AddChild(serverInfo);
                self.Add(serverInfo.Id);
            }

            await ETTask.CompletedTask;
        }
    }
}