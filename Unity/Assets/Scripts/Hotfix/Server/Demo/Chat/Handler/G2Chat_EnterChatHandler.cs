namespace ET.Server
{
    [FriendOf(typeof(ChatUnit))]
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_EnterChatHandler : MessageHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response)
        {
            Log.Debug($"玩家：{request.UnitId} 登录聊天服");

            ChatUnitComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatUnitComponent>();
            ChatUnit chatUnit = chatInfoUnitsComponent.Get(request.UnitId);

            if (chatUnit != null && !chatUnit.IsDisposed)
            {
                chatUnit.Name = request.Name;
                return;
            }

            chatUnit = chatInfoUnitsComponent.AddChildWithId<ChatUnit>(request.UnitId);
            chatInfoUnitsComponent.Add(chatUnit);
            chatUnit.Name = request.Name;
            chatUnit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            await chatUnit.AddLocation(LocationType.Chat);

            await ETTask.CompletedTask;
        }
    }
}