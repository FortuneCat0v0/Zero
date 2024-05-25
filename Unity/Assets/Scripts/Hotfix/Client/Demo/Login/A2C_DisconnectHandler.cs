namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class A2C_DisconnectHandler : MessageHandler<Scene, A2C_Disconnect>
    {
        protected override async ETTask Run(Scene root, A2C_Disconnect message)
        {
            Log.Warning($"当前与服务器断开连接，连接错误码为: {message.Error}");
            await ETTask.CompletedTask;
        }
    }
}