using System;

namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class G2L_AddLoginRecordHandler: MessageHandler<Scene, G2L_AddLoginRecord, L2G_AddLoginRecord>
    {
        protected override async ETTask Run(Scene scene, G2L_AddLoginRecord request, L2G_AddLoginRecord response)
        {
            long accountId = request.AccountId;
            using (await scene.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                scene.GetComponent<LoginInfoRecordComponent>().Remove(accountId);
                scene.GetComponent<LoginInfoRecordComponent>().Add(accountId, request.ServerId);
            }
        }
    }
}