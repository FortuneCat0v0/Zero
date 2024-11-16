namespace ET.Server
{
    [FriendOf(typeof(KnapsackComponent))]
    [EntitySystemOf(typeof(KnapsackComponent))]
    public static partial class KnapsackComponentSystem
    {
        [EntitySystem]
        private static void Awake(this KnapsackComponent self)
        {
            KnapsackContainerComponent inventory = self.AddChild<KnapsackContainerComponent, int>((int)KnapsackContainerType.Inventory);
            self.ContainerInfoDic.Add((int)KnapsackContainerType.Inventory, inventory);

            KnapsackContainerComponent warehouse = self.AddChild<KnapsackContainerComponent, int>((int)KnapsackContainerType.Warehouse);
            self.ContainerInfoDic.Add((int)KnapsackContainerType.Warehouse, warehouse);
        }

        [EntitySystem]
        private static void Destroy(this KnapsackComponent self)
        {
            self.ContainerInfoDic.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this KnapsackComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                if (entity is KnapsackContainerComponent knapsackContainerComponent)
                {
                    self.ContainerInfoDic.Add(knapsackContainerComponent.KnapsackContainerType, knapsackContainerComponent);
                }
            }
        }

        public static void GetAllItems(this KnapsackComponent self, ListComponent<Item> itemList)
        {
            foreach (KnapsackContainerComponent knapsackContainerComponent in self.ContainerInfoDic.Values)
            {
                knapsackContainerComponent.GetItems(itemList);
            }
        }

        public static KnapsackContainerComponent GetContainer(this KnapsackComponent self, int containerType)
        {
            self.ContainerInfoDic.TryGetValue(containerType, out EntityRef<KnapsackContainerComponent> containerComponent);
            return containerComponent;
        }
    }
}