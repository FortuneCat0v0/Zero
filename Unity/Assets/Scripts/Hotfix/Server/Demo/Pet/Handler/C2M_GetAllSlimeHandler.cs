namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetAllPetHandler : MessageLocationHandler<Unit, C2M_GetAllPet, M2C_GetAllPet>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllPet request, M2C_GetAllPet response)
        {
            using (ListComponent<Pet> petList = ListComponent<Pet>.Create())
            {
                unit.GetComponent<PetComponent>().GetSlimes(petList);
                foreach (Pet pet in petList)
                {
                    response.PetList.Add(pet.ToMessage());
                }
            }

            await ETTask.CompletedTask;
        }
    }
}