using System.Collections.Generic;
using YIUIFramework;

namespace ET.Client
{
    [GM(EGMType.Test, 1, "背包测试-添加道具")]
    public class GM_Command_Knapsack1 : IGMCommand
    {
        public List<GMParamInfo> GetParams()
        {
            return new()
            {
                new GMParamInfo(EGMParamType.Enum, "容器", "ET.KnapsackContainerType"),
                new GMParamInfo(EGMParamType.Int, "ItemId")
            };
        }

        public async ETTask<bool> Run(Scene root, ParamVo paramVo)
        {
            var paramEnum = paramVo.Get<KnapsackContainerType>(0);
            var paramInt = paramVo.Get<int>(1);

            await KnapsackHelper.RequestAddItem(root, paramEnum, paramInt);

            await ETTask.CompletedTask;
            return true;
        }
    }

    [GM(EGMType.Test, 1, "背包测试-删除道具")]
    public class GM_Command_Knapsack2 : IGMCommand
    {
        public List<GMParamInfo> GetParams()
        {
            return new()
            {
                new GMParamInfo(EGMParamType.Enum, "容器", "ET.KnapsackContainerType"),
                new GMParamInfo(EGMParamType.Int, "ItemId"),
            };
        }

        public async ETTask<bool> Run(Scene root, ParamVo paramVo)
        {
            var paramEnum = paramVo.Get<KnapsackContainerType>(0);
            var paramInt = paramVo.Get<int>(1);

            await KnapsackHelper.RequestRemoveItem(root, paramEnum, paramInt);

            await ETTask.CompletedTask;
            return true;
        }
    }
}