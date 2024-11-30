using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(RankEntity))]
    [FriendOf(typeof(RankComponent))]
    [EntitySystemOf(typeof(RankComponent))]
    public static partial class RankComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RankComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RankComponent self)
        {
        }

        public static async ETTask LoadRankInfos(this RankComponent self)
        {
            // 从数据库中加载和读取排行榜数据

            // 临时数据
            RankEntity rankEntity1 = self.AddChild<RankEntity>();
            rankEntity1.UnitId = 100;
            rankEntity1.Name = "玩家甲";
            self.RankInfos.Add(rankEntity1);
            RankEntity rankEntity2 = self.AddChild<RankEntity>();
            rankEntity2.UnitId = 200;
            rankEntity2.Name = "玩家乙";
            self.RankInfos.Add(rankEntity2);

            await ETTask.CompletedTask;
        }

        public static List<RankInfo> GetRankInfos(this RankComponent self)
        {
            List<RankInfo> rankInfos = new();

            foreach (RankEntity rankEntity in self.RankInfos)
            {
                RankInfo rankInfo = RankInfo.Create();
                rankInfo.Id = rankEntity.Id;
                rankInfo.UnitId = rankEntity.UnitId;
                rankInfo.Name = rankEntity.Name;
                rankInfos.Add(rankInfo);
            }

            return rankInfos;
        }
    }
}