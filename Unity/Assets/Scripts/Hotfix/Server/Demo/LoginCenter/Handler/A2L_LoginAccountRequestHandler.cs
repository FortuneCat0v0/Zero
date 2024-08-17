namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class A2L_LoginAccountRequestHandler : MessageHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response)
        {
            long accountId = request.AccountId;

            using (await scene.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                // 当前账号没有在线，直接返回
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    return;
                }

                // 当前账号已在线，通知Gate踢玩家下线
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, accountId);

                L2G_DisconnectGateUnit l2GDisconnectGateUnit = L2G_DisconnectGateUnit.Create();
                l2GDisconnectGateUnit.AccountId = accountId;
                G2L_DisconnectGateUnit g2LDisconnectGateUnit = await scene.GetComponent<MessageSender>().Call(gateConfig.ActorId,
                    l2GDisconnectGateUnit) as G2L_DisconnectGateUnit;

                response.Error = g2LDisconnectGateUnit.Error;
            }
        }
    }
}