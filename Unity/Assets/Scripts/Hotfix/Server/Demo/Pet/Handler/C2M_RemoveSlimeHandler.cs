namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RemovePetHandler : MessageLocationHandler<Unit, C2M_RemovePet, M2C_RemovePet>
    {
        protected override async ETTask Run(Unit unit, C2M_RemovePet request, M2C_RemovePet response)
        {
            PetComponent petComponent = unit.GetComponent<PetComponent>();
            petComponent.RemoveSlime(request.PetId);

            await ETTask.CompletedTask;
        }
    }
}