using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class G2M_RequestExitGameHandler : MessageLocationHandler<Unit, G2M_RequestExitGame>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestExitGame request)
        {
            //下线逻辑

            //保存玩家数据到数据库，执行相关下线操作
            Log.Debug("开始下线保存玩家数据");
            await unit.GetComponent<UnitDBSaveComponent>().SaveChange();

            //正式释放Unit
            await unit.RemoveLocation(LocationType.Unit);
            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();
            unitComponent.Remove(unit.Id);

            await ETTask.CompletedTask;
        }
    }
}