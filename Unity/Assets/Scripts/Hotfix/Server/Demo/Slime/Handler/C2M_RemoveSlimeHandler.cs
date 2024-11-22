namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RemoveSlimeHandler : MessageLocationHandler<Unit, C2M_RemoveSlime, M2C_RemoveSlime>
    {
        protected override async ETTask Run(Unit unit, C2M_RemoveSlime request, M2C_RemoveSlime response)
        {
            SlimeComponent slimeComponent = unit.GetComponent<SlimeComponent>();
            slimeComponent.RemoveSlime(request.SlimeId);

            await ETTask.CompletedTask;
        }
    }
}