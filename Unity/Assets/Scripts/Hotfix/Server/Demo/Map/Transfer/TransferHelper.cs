namespace ET.Server
{
    public static partial class TransferHelper
    {
        public static async ETTask TransferAtFrameFinish(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, sceneName);
        }

        public static async ETTask Transfer(Unit unit, ActorId sceneInstanceId, string sceneName)
        {
            Scene root = unit.Root();

            // location加锁
            long unitId = unit.Id;

            unit.GetComponent<UnitDBSaveComponent>().SaveChangeNoWait();
            
            M2M_UnitTransferRequest request = M2M_UnitTransferRequest.Create();
            request.OldActorId = unit.GetActorId();
            request.Unit = unit.ToBson();
            // foreach (Entity entity in unit.Components.Values)
            // {
            //     if (entity is ITransfer)
            //     {
            //         request.Entitys.Add(entity.ToBson());
            //     }
            // }

            foreach (var kv in unit.GetComponent<UnitDBSaveComponent>().Bytes)
            {
                request.Types.Add(kv.Key.FullName);
                request.Entitys.Add(kv.Value);
            }

            unit.Dispose();

            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Unit, unitId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }
    }
}