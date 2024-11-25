namespace ET.Client
{
    public static class SlimeHelper
    {
        public static async ETTask<int> GetAllSlimes(Scene root)
        {
            C2M_GetAllSlime request = C2M_GetAllSlime.Create();

            M2C_GetAllSlime response = (M2C_GetAllSlime)await root.GetComponent<ClientSenderComponent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ClientSlimeComponent slimeComponent = root.GetComponent<ClientSlimeComponent>();
            slimeComponent.Clear();
            foreach (SlimeInfo slimeInfo in response.SlimeList)
            {
                slimeComponent.AddSlimeFromMessage(slimeInfo);
            }

            return response.Error;
        }

        public static async ETTask<int> RequestAddSlime(Scene root, int configId)
        {
            C2M_AddSlime request = C2M_AddSlime.Create();
            request.ConfigId = configId;

            M2C_AddSlime response = (M2C_AddSlime)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestRemoveSlime(Scene root, long slimeId)
        {
            C2M_RemoveSlime request = C2M_RemoveSlime.Create();
            request.SlimeId = slimeId;

            M2C_RemoveSlime response = (M2C_RemoveSlime)await root.GetComponent<ClientSenderComponent>().Call(request);
            return response.Error;
        }
    }
}