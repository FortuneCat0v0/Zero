namespace ET.Server
{
    [MessageHandler(SceneType.Realm)]
    public class A2R_GetRealmKeyHandler : MessageHandler<Scene, A2R_GetRealmKey, R2A_GetRealmKey>
    {
        protected override async ETTask Run(Scene scene, A2R_GetRealmKey request, R2A_GetRealmKey response)
        {
            string key = TimeInfo.Instance.ServerNow() + RandomGenerator.RandInt64().ToString();
            scene.GetComponent<TokenComponent>().Remove(request.AccountId);
            scene.GetComponent<TokenComponent>().Add(request.AccountId, key);
            response.RealmKey = key;
            await ETTask.CompletedTask;
        }
    }
}