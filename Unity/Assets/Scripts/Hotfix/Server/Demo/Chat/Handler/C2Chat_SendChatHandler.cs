namespace ET.Server
{
    [MessageHandler(SceneType.Chat)]
    public class C2Chat_SendChatHandler : MessageHandler<ChatUnit, C2Chat_SendChat, Chat2C_SendChat>
    {
        protected override async ETTask Run(ChatUnit chatUnit, C2Chat_SendChat request, Chat2C_SendChat response)
        {
            if (string.IsNullOrEmpty(request.ChatMessage))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                return;
            }

            ChatUnitComponent chatUnitComponent = chatUnit.Root().GetComponent<ChatUnitComponent>();
            foreach (ChatUnit otherUnit in chatUnitComponent.ChatUnitDict.Values)
            {
                Chat2C_NoticeChat chat2C_NoticeChat = Chat2C_NoticeChat.Create();
                chat2C_NoticeChat.Name = otherUnit.Name;
                chat2C_NoticeChat.ChatMessage = request.ChatMessage;

                MapMessageHelper.SendToClient(chatUnit.Root(), otherUnit.Id, chat2C_NoticeChat);
            }

            await ETTask.CompletedTask;
        }
    }
}