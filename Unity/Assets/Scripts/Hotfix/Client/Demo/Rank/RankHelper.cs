using System.Collections.Generic;

namespace ET.Client
{
    public static class RankHelper
    {
        public static async ETTask<List<RankInfo>> GetRankInfo(Scene root)
        {
            C2Rank_GetRanksInfo request = C2Rank_GetRanksInfo.Create();

            Rank2C_GetRanksInfo response = (Rank2C_GetRanksInfo)await root.GetComponent<ClientSenderComponent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return null;
            }

            return response.RankInfoList;
        }
    }
}