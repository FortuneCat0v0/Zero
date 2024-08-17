namespace ET.Server
{
    [MessageHandler(SceneType.Gate)]
    public class R2G_GetLoginGateKeyHandler: MessageHandler<Scene, R2G_GetLoginGateKey, G2R_GetLoginGateKey>
    {
        protected override async ETTask Run(Scene scene, R2G_GetLoginGateKey request, G2R_GetLoginGateKey response)
        {
            string key = RandomHelper.RandInt64().ToString() + TimeInfo.Instance.ServerNow().ToString();
            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            scene.GetComponent<GateSessionKeyComponent>().Add(request.AccountId, key);
            response.GateSessionKey = key;
            await ETTask.CompletedTask;
        }
    }
}