using System.Collections.Generic;

namespace ET
{
    public static class ConfigData
    {
        /// <summary>
        /// 赠送钻石数量
        /// </summary>
        [StaticField]
        public static Dictionary<int, int> RechargeGive = new()
        {
            { 6, 0 },
            { 30, 300 },
            { 50, 600 },
            { 98, 1200 },
            { 198, 2888 },
            { 298, 4888 },
            { 488, 8888 },
            { 648, 12888 },
        };
    }
}