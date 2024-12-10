namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AddPetHandler : MessageLocationHandler<Unit, C2M_AddPet, M2C_AddPet>
    {
        protected override async ETTask Run(Unit unit, C2M_AddPet request, M2C_AddPet response)
        {
            PetComponent petComponent = unit.GetComponent<PetComponent>();
            Pet pet = PetFactory.CreateSlime(petComponent, request.ConfigId);
            petComponent.AddSlime(pet);

            await ETTask.CompletedTask;
        }
    }
}