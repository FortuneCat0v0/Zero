namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AddKnapsackItemHandler : MessageLocationHandler<Unit, C2M_AddKnapsackItem, M2C_AddKnapsackItem>
    {
        protected override async ETTask Run(Unit unit, C2M_AddKnapsackItem request, M2C_AddKnapsackItem response)
        {
            KnapsackContainerComponent containerComponent = unit.GetComponent<KnapsackComponent>().GetContainer(request.ContainerType);
            Item item = ItemFactory.CreateItem(containerComponent, request.ContainerType);
            containerComponent.AddItem(item);

            await ETTask.CompletedTask;
        }
    }
}