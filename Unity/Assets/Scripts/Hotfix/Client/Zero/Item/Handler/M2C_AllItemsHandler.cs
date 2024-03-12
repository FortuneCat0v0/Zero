namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_AllItemsHandler : MessageHandler<Scene, M2C_AllItems>
    {
        protected override async ETTask Run(Scene root, M2C_AllItems message)
        {
            ItemHelper.Clear(root, (ItemContainerType)message.ItemContainerType);

            for (int i = 0; i < message.ItemInfos.Count; i++)
            {
                Item item = ItemFactory.Create(root, message.ItemInfos[i]);
                ItemHelper.AddItem(root, item, (ItemContainerType)message.ItemContainerType);
            }

            await ETTask.CompletedTask;
        }
    }
}