namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ItemUpdateOpHandler : MessageHandler<Scene, M2C_ItemUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_ItemUpdateOp message)
        {
            switch ((ItemContainerType)message.ItemContainerType)
            {
                case ItemContainerType.Bag:
                    BagComponent bagComponent = root.GetComponent<BagComponent>();
                    switch (message.ItemOpType)
                    {
                        case (int)ItemOpType.Add:
                            Item item = ItemFactory.Create(root, message.ItemInfo);
                            bagComponent.AddItem(item);

                            break;
                        case (int)ItemOpType.Remove:
                            bagComponent.RemoveItem(message.ItemInfo.Id);

                            break;
                    }

                    break;
                case ItemContainerType.Equipment:
                    EquipmentComponent equipmentComponent = root.GetComponent<EquipmentComponent>();
                    switch (message.ItemOpType)
                    {
                        case (int)ItemOpType.Add:
                            Item item = ItemFactory.Create(root, message.ItemInfo);
                            equipmentComponent.EquipItem((EquipPosition)message.EquipPosition, item);

                            break;
                        case (int)ItemOpType.Remove:
                            equipmentComponent.RemoveEquipItem((EquipPosition)message.EquipPosition);

                            break;
                    }

                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}