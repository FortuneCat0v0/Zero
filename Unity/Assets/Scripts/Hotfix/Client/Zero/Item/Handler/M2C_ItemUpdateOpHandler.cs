namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ItemUpdateOpHandler : MessageHandler<Scene, M2C_ItemUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_ItemUpdateOp message)
        {
            switch (message.ItemOpType)
            {
                case (int)ItemOpType.Add:
                    Item item = ItemFactory.Create(root, message.ItemInfo);
                    ItemHelper.AddItem(root, item, (ItemContainerType)message.ItemContainerType);

                    break;
                case (int)ItemOpType.Remove:
                    ItemHelper.RemoveItem(root, message.ItemInfo.Id, (ItemContainerType)message.ItemContainerType);

                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}