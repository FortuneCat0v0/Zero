namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RemoveKnapsackItemHandler : MessageLocationHandler<Unit, C2M_RemoveKnapsackItem, M2C_RemoveKnapsackItem>
    {
        protected override async ETTask Run(Unit unit, C2M_RemoveKnapsackItem request, M2C_RemoveKnapsackItem response)
        {
            KnapsackContainerComponent containerComponent = unit.GetComponent<KnapsackComponent>().GetContainer(request.ContainerType);
            containerComponent.RemoveItem(request.ItemId);

            await ETTask.CompletedTask;
        }
    }
}