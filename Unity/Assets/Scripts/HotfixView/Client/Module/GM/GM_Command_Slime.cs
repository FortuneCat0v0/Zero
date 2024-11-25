using System.Collections.Generic;
using YIUIFramework;

namespace ET.Client
{
    [GM(EGMType.Test, 1, "史莱姆测试-添加史莱姆")]
    public class GM_Command_Slime1 : IGMCommand
    {
        public List<GMParamInfo> GetParams()
        {
            return new()
            {
                new GMParamInfo(EGMParamType.Int, "ConfigId"),
            };
        }

        public async ETTask<bool> Run(Scene root, ParamVo paramVo)
        {
            var paramInt = paramVo.Get<int>();

            await SlimeHelper.RequestAddSlime(root, paramInt);

            await ETTask.CompletedTask;
            return true;
        }
    }

    [GM(EGMType.Test, 1, "史莱姆测试-删除史莱姆")]
    public class GM_Command_Slime2 : IGMCommand
    {
        public List<GMParamInfo> GetParams()
        {
            return new()
            {
                new GMParamInfo(EGMParamType.Int, "SlimeId"),
            };
        }

        public async ETTask<bool> Run(Scene root, ParamVo paramVo)
        {
            var paramInt = paramVo.Get<int>();

            await SlimeHelper.RequestRemoveSlime(root, paramInt);

            await ETTask.CompletedTask;
            return true;
        }
    }
}