namespace ET.Client
{
    public static class KnapsackHelper
    {
        public static async ETTask<int> GetAllItems(Scene root)
        {
            C2M_GetAllKnapsack request = C2M_GetAllKnapsack.Create();

            M2C_GetAllKnapsack response = (M2C_GetAllKnapsack)await root.GetComponent<ClientSenderComponent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ClientKnapsackComponent clientKnapsackComponent = root.GetComponent<ClientKnapsackComponent>();
            clientKnapsackComponent.ClearAllItems();
            foreach (ItemInfo itemInfo in response.ItemList)
            {
                clientKnapsackComponent.GetContainer(itemInfo.ContainerType).AddItemFromMessage(itemInfo);
            }

            return response.Error;
        }

        public static async ETTask<int> RequestAddItem(Scene root, KnapsackContainerType containerType, int configId)
        {
            C2M_AddKnapsackItem request = C2M_AddKnapsackItem.Create();
            request.ContainerType = (int)containerType;
            request.ConfigId = configId;

            M2C_AddKnapsackItem response = (M2C_AddKnapsackItem)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestRemoveItem(Scene root, KnapsackContainerType containerType, int itemId)
        {
            C2M_RemoveKnapsackItem request = C2M_RemoveKnapsackItem.Create();
            request.ContainerType = (int)containerType;
            request.ItemId = itemId;

            M2C_RemoveKnapsackItem response = (M2C_RemoveKnapsackItem)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }
    }
}