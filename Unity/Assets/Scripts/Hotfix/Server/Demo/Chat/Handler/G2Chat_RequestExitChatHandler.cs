namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_RequestExitChatHandler : MessageLocationHandler<ChatUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatUnit chatUnit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response)
        {
            ChatUnitExit(chatUnit).Coroutine();

            await ETTask.CompletedTask;
        }

        private async ETTask ChatUnitExit(ChatUnit chatUnit)
        {
            await chatUnit.Fiber().WaitFrameFinish();
            await chatUnit.RemoveLocation(LocationType.Chat);
            chatUnit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Remove(chatUnit.Id);
            chatUnit?.Dispose();

            await ETTask.CompletedTask;
        }
    }
}