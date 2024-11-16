namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetAllKnapsackHandler : MessageLocationHandler<Unit, C2M_GetAllKnapsack, M2C_GetAllKnapsack>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllKnapsack request, M2C_GetAllKnapsack response)
        {
            using (ListComponent<Item> items = ListComponent<Item>.Create())
            {
                unit.GetComponent<KnapsackComponent>().GetAllItems(items);
                foreach (Item item in items)
                {
                    response.ItemList.Add(item.ToMessage());
                }
            }

            await ETTask.CompletedTask;
        }
    }
}