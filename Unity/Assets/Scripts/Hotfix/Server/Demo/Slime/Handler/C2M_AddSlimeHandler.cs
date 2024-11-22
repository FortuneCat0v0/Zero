namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AddSlimeHandler : MessageLocationHandler<Unit, C2M_AddSlime, M2C_AddSlime>
    {
        protected override async ETTask Run(Unit unit, C2M_AddSlime request, M2C_AddSlime response)
        {
            SlimeComponent slimeComponent = unit.GetComponent<SlimeComponent>();
            Slime slime = SlimeFactory.CreateSlime(slimeComponent, request.ConfigId);
            slimeComponent.AddSlime(slime);

            await ETTask.CompletedTask;
        }
    }
}