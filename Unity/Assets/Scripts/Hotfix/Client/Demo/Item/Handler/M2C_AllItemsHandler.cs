namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_AllItemsHandler : MessageHandler<Scene, M2C_AllItems>
    {
        protected override async ETTask Run(Scene root, M2C_AllItems message)
        {
            await ETTask.CompletedTask;
        }
    }
}