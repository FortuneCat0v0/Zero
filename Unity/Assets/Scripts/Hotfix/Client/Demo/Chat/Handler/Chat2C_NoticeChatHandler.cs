namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Chat2C_NoticeChatHandler : MessageHandler<Scene, Chat2C_NoticeChat>
    {
        protected override async ETTask Run(Scene root, Chat2C_NoticeChat message)
        {
            // ChatInfo chatInfo = root.GetComponent<ChatComponent>().AddChild<ChatInfo>(true);
            // chatInfo.Name = message.Name;
            // chatInfo.Message = message.ChatMessage;
            // session.DomainScene().GetComponent<ChatComponent>().Add(chatInfo);
            // Game.EventSystem.Publish(new EventType.UpdateChatInfo() { ZoneScene = session.ZoneScene() });

            await ETTask.CompletedTask;
        }
    }
}