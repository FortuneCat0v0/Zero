namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SlimeUpdateOpHandler : MessageHandler<Scene, M2C_SlimeUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_SlimeUpdateOp message)
        {
            ClientSlimeComponent clientSlimeComponent = root.GetComponent<ClientSlimeComponent>();

            if (message.SlimeOpType == (int)ItemOpType.Add)
            {
                clientSlimeComponent?.AddSlimeFromMessage(message.SlimeInfo);
            }
            else if (message.SlimeOpType == (int)ItemOpType.Remove)
            {
                clientSlimeComponent?.RemoveSlimeById(message.SlimeInfo.Id);
            }
            else if (message.SlimeOpType == (int)ItemOpType.Update)
            {
                clientSlimeComponent?.UpdateSlime(message.SlimeInfo);
            }

            EventSystem.Instance.Publish(root, new SlimeInfoChange() { SlimeInfo = message.SlimeInfo });

            await ETTask.CompletedTask;
        }
    }
}