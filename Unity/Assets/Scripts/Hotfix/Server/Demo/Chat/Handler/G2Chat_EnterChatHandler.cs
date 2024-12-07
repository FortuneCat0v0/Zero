namespace ET.Server
{
    [FriendOf(typeof(ChatUnit))]
    [MessageHandler(SceneType.Chat)]
    public class G2Chat_EnterChatHandler : MessageHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response)
        {
            ChatUnitComponent chatInfoUnitsComponent = scene.Root().GetComponent<ChatUnitComponent>();
            chatInfoUnitsComponent.Children.TryGetValue(request.UnitId, out Entity chatUnitEntity);

            ChatUnit chatUnit = chatUnitEntity as ChatUnit;

            if (chatUnit != null)
            {
                chatUnit.Name = request.Name;
                return;
            }

            chatUnit = chatInfoUnitsComponent.AddChildWithId<ChatUnit>(request.UnitId);
            chatUnit.Name = request.Name;

            chatUnit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            await chatUnit.AddLocation(LocationType.Chat);

            await ETTask.CompletedTask;
        }
    }
}