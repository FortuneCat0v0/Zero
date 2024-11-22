namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ItemUpdateOpHandler : MessageHandler<Scene, M2C_ItemUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_ItemUpdateOp message)
        {
            ClientKnapsackContainerComponent container = root.GetComponent<ClientKnapsackComponent>().GetContainer(message.ItemInfo.ContainerType);

            if (message.ItemOpType == (int)ItemOpType.Add)
            {
                container?.AddItemFromMessage(message.ItemInfo);
            }
            else if (message.ItemOpType == (int)ItemOpType.Remove)
            {
                container?.RemoveItemById(message.ItemInfo.Id);
            }
            else if (message.ItemOpType == (int)ItemOpType.Update)
            {
                container?.UpdateItem(message.ItemInfo);
            }

            EventSystem.Instance.Publish(root, new ItemInfoChange() { ItemInfo = message.ItemInfo });

            await ETTask.CompletedTask;
        }
    }
}