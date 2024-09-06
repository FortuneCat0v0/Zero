using System;

namespace ET.Server
{
    // [MessageHandler(SceneType.Map)]
    // public class G2M_RequestExitGameHandler : MessageHandler<Unit, G2M_RequestExitGame, M2G_RequestExitGame>
    // {
    //     protected override async ETTask Run(Unit unit, G2M_RequestExitGame request, M2G_RequestExitGame response, Action reply)
    //     {
    //         //下线逻辑
    //
    //         //保存玩家数据到数据库，执行相关下线操作
    //         Log.Debug("开始下线保存玩家数据");
    //         unit.GetComponent<UnitDBSaveComponent>()?.SaveChange();
    //
    //         reply();
    //
    //         //正式释放Unit
    //         await unit.RemoveLocation();
    //         UnitComponent unitComponent = unit.DomainScene().GetComponent<UnitComponent>();
    //         unitComponent.Remove(unit.Id);
    //
    //         await ETTask.CompletedTask;
    //     }
    // }
}