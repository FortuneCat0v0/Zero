﻿using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_RequestEnterGameHandler : MessageLocationHandler<Unit, G2M_RequestEnterGame, M2G_RequestEnterGame>
    {
        protected override async ETTask Run(Unit chatUnit, G2M_RequestEnterGame request, M2G_RequestEnterGame response)
        {
            // 重连逻辑
            TransferHelper.NoticeClient(chatUnit.Scene(), chatUnit);

            await ETTask.CompletedTask;
        }
    }
}