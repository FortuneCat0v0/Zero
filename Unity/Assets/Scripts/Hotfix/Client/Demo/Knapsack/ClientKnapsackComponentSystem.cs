namespace ET.Client
{
    [FriendOf(typeof(ClientKnapsackComponent))]
    [EntitySystemOf(typeof(ClientKnapsackComponent))]
    public static partial class ClientKnapsackComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientKnapsackComponent self)
        {
            ClientKnapsackContainerComponent inventory = self.AddChild<ClientKnapsackContainerComponent, int>((int)KnapsackContainerType.Inventory);
            self.ContainerInfoDic.Add((int)KnapsackContainerType.Inventory, inventory);

            ClientKnapsackContainerComponent warehouse = self.AddChild<ClientKnapsackContainerComponent, int>((int)KnapsackContainerType.Warehouse);
            self.ContainerInfoDic.Add((int)KnapsackContainerType.Warehouse, warehouse);
        }

        [EntitySystem]
        private static void Destroy(this ClientKnapsackComponent self)
        {
            self.ContainerInfoDic.Clear();
            self.ContainerInfoDic = null;
        }

        public static ClientKnapsackContainerComponent GetContainer(this ClientKnapsackComponent self, int containerType)
        {
            if (!self.ContainerInfoDic.TryGetValue(containerType, out EntityRef<ClientKnapsackContainerComponent> container))
            {
                Log.Error($"container not found type: {(KnapsackContainerType)containerType}");
            }

            return container;
        }

        public static void ClearAllItems(this ClientKnapsackComponent self)
        {
            foreach (ClientKnapsackContainerComponent knapsackContainerComponent in self.ContainerInfoDic.Values)
            {
                knapsackContainerComponent.Clear();
            }
        }
    }
}