using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.Account)]
    public class FiberInit_Account : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get(root.Fiber.Id);
            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);

            root.AddComponent<DBManagerComponent>();
            root.AddComponent<TokenComponent>();
            root.AddComponent<AccountSessionComponent>();
            root.AddComponent<GameServerComponent>();
            await ETTask.CompletedTask;
        }
    }
}