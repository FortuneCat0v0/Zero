namespace ET.Server.Handler
{
    [MessageHandler(SceneType.Rank)]
    public class C2Rank_GetRanksInfoHandler : MessageHandler<Scene, C2Rank_GetRanksInfo, Rank2C_GetRanksInfo>
    {
        protected override async ETTask Run(Scene scene, C2Rank_GetRanksInfo request, Rank2C_GetRanksInfo response)
        {
            RankComponent rankComponent = scene.GetComponent<RankComponent>();
            response.RankInfoList = rankComponent.GetRankInfos();

            await ETTask.CompletedTask;
        }
    }
}