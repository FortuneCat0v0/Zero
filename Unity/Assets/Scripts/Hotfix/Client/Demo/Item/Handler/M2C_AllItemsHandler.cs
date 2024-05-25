using System;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_AllItemsHandler : MessageHandler<Scene, M2C_AllItems>
    {
        protected override async ETTask Run(Scene root, M2C_AllItems message)
        {
            ItemHelper.Clear(root, (ItemContainerType)message.ItemContainerType);

            switch ((ItemContainerType)message.ItemContainerType)
            {
                case ItemContainerType.Bag:
                    BagComponent bagComponent = root.GetComponent<BagComponent>();
                    bagComponent.Clear();
                    for (int i = 0; i < message.ItemInfos.Count; i++)
                    {
                        Item item = ItemFactory.Create(root, message.ItemInfos[i]);
                        bagComponent.AddItem(item);
                    }

                    break;
                case ItemContainerType.Equipment:
                    EquipmentComponent equipmentComponent = root.GetComponent<EquipmentComponent>();
                    equipmentComponent.Clear();
                    for (int i = 0; i < message.EquipPositions.Count; i++)
                    {
                        Item item = ItemFactory.Create(root, message.ItemInfos[i]);
                        equipmentComponent.EquipItem((EquipPosition)message.EquipPositions[i], item);
                    }

                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}