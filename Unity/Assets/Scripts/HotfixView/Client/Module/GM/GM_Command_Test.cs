using System.Collections.Generic;
using UnityEngine;
using YIUIFramework;

namespace ET.Client
{
    //1 所在页签
    //2 命令等级 当执行人等级不足时无法使用
    //3 命令名称 页面上显示的名字
    //4 命令描述 有描述时显示描述 没有时不显示
    [GM(EGMType.Test, 1, "测试案列", "测试案列描述.....")]
    public class GM_Test : IGMCommand
    {
        public List<GMParamInfo> GetParams()
        {
            return new()
            {
                //目前有6种参数类型可选 长度无限
                //根据需求这里设定对应参数类型与描述 将在页面上显示
                new GMParamInfo(EGMParamType.Enum, "参数0 枚举", "ET.Client.EGMParamType"), //枚举案例 一定要写枚举全名
                new GMParamInfo(EGMParamType.String, "参数1 字符串"),
                new GMParamInfo(EGMParamType.Bool, "参数2 布尔"),
                new GMParamInfo(EGMParamType.Float, "参数3 小数"),
                new GMParamInfo(EGMParamType.Int, "参数4 整数"),
                new GMParamInfo(EGMParamType.Long, "参数5 64整数"),
            };
        }

        public async ETTask<bool> Run(Scene root, ParamVo paramVo)
        {
            //通过paramvo 可以取出所有参数
            var paramEnum = paramVo.Get<EGMParamType>(0);
            var paramString = paramVo.Get<string>(1);
            var paramBool = paramVo.Get<bool>(2);
            var paramFloat = paramVo.Get<float>(3);
            var paramInt = paramVo.Get<int>(4);
            var paramLong = paramVo.Get<long>(5);

            //最后根据参数自行处理命令
            Debug.LogError($"参数0: {paramEnum}");
            Debug.LogError($"参数1: {paramString}");
            Debug.LogError($"参数2: {paramBool}");
            Debug.LogError($"参数3: {paramFloat}");
            Debug.LogError($"参数4: {paramInt}");
            Debug.LogError($"参数5: {paramLong}");

            await ETTask.CompletedTask;
            return true;
        }

        # region 聊天

        [GM(EGMType.Test, 1, "聊天测试-发送信息")]
        public class GM_Command_Chat1 : IGMCommand
        {
            public List<GMParamInfo> GetParams()
            {
                return new()
                {
                    new GMParamInfo(EGMParamType.String, "内容")
                };
            }

            public async ETTask<bool> Run(Scene root, ParamVo paramVo)
            {
                var paramString = paramVo.Get<string>();

                await ChatHelper.RequestSendChat(root, paramString);

                await ETTask.CompletedTask;
                return true;
            }
        }

        #endregion

        # region 背包

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
                    new GMParamInfo(EGMParamType.Long, "ItemId"),
                };
            }

            public async ETTask<bool> Run(Scene root, ParamVo paramVo)
            {
                var paramEnum = paramVo.Get<KnapsackContainerType>(0);
                var paramLong = paramVo.Get<long>(1);

                await KnapsackHelper.RequestRemoveItem(root, paramEnum, paramLong);

                await ETTask.CompletedTask;
                return true;
            }
        }

        # endregion

        # region 史莱姆

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

                await PetHelper.RequestAddPet(root, paramInt);

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
                    new GMParamInfo(EGMParamType.Long, "SlimeId"),
                };
            }

            public async ETTask<bool> Run(Scene root, ParamVo paramVo)
            {
                var paramLong = paramVo.Get<long>();

                await PetHelper.RequestRemovePet(root, paramLong);

                await ETTask.CompletedTask;
                return true;
            }
        }

        # endregion

        # region 排行榜

        [GM(EGMType.Test, 1, "Rank测试-获取RankInfo")]
        public class GM_Command_Rank1 : IGMCommand
        {
            public List<GMParamInfo> GetParams()
            {
                return new()
                {
                };
            }

            public async ETTask<bool> Run(Scene root, ParamVo paramVo)
            {
                await RankHelper.GetRankInfo(root);

                await ETTask.CompletedTask;
                return true;
            }
        }

        #endregion

        # region 邮件

        [GM(EGMType.Test, 1, "Mail测试-获取MailInfo")]
        public class GM_Command_Mail1 : IGMCommand
        {
            public List<GMParamInfo> GetParams()
            {
                return new()
                {
                };
            }

            public async ETTask<bool> Run(Scene root, ParamVo paramVo)
            {
                await MailHelper.GetMailInfo(root);

                await ETTask.CompletedTask;
                return true;
            }
        }

        #endregion
    }
}