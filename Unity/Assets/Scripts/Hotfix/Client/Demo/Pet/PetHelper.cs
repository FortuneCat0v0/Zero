namespace ET.Client
{
    public static class PetHelper
    {
        public static async ETTask<int> GetAllPets(Scene root)
        {
            C2M_GetAllPet request = C2M_GetAllPet.Create();

            M2C_GetAllPet response = (M2C_GetAllPet)await root.GetComponent<ClientSenderComponent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ClientPetComponent petComponent = root.GetComponent<ClientPetComponent>();
            petComponent.Clear();
            foreach (PetInfo slimeInfo in response.PetList)
            {
                petComponent.AddSlimeFromMessage(slimeInfo);
            }

            return response.Error;
        }

        public static async ETTask<int> RequestAddPet(Scene root, int configId)
        {
            C2M_AddPet request = C2M_AddPet.Create();
            request.ConfigId = configId;

            M2C_AddPet response = (M2C_AddPet)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestRemovePet(Scene root, long petId)
        {
            C2M_RemovePet request = C2M_RemovePet.Create();
            request.PetId = petId;

            M2C_RemovePet response = (M2C_RemovePet)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }
    }
}