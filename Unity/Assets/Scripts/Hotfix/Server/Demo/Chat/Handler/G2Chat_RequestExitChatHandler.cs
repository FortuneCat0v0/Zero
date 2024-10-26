namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_RequestExitChatHandler : MessageLocationHandler<ChatUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatUnit chatUnit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response)
        {
            Log.Debug($"玩家：{chatUnit.Id} 登录聊天服");

            ChatUnitComponent chatInfoUnitsComponent = chatUnit.Root().GetComponent<ChatUnitComponent>();
            chatInfoUnitsComponent.Remove(chatUnit.Id);

            await ETTask.CompletedTask;
        }
    }
}