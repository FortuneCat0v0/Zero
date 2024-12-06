namespace ET.Client
{
    public static class ChatHelper
    {
        public static async ETTask<int> RequestSendChat(Scene root, string message)
        {
            C2Chat_SendChat request = C2Chat_SendChat.Create();
            request.ChatMessage = message;

            Chat2C_SendChat response = (Chat2C_SendChat)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }
    }
}