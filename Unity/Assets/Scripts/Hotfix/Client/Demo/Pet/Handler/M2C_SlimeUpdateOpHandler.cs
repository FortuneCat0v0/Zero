namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetUpdateOpHandler : MessageHandler<Scene, M2C_PetUpdateOp>
    {
        protected override async ETTask Run(Scene root, M2C_PetUpdateOp message)
        {
            ClientPetComponent clientPetComponent = root.GetComponent<ClientPetComponent>();

            if (message.PetOpType == (int)PetOpType.Add)
            {
                clientPetComponent?.AddSlimeFromMessage(message.PetInfo);
            }
            else if (message.PetOpType == (int)PetOpType.Remove)
            {
                clientPetComponent?.RemovePetById(message.PetInfo.Id);
            }
            else if (message.PetOpType == (int)PetOpType.Update)
            {
                clientPetComponent?.UpdatePet(message.PetInfo);
            }

            EventSystem.Instance.Publish(root, new PetInfoChange() { PetInfo = message.PetInfo });

            await ETTask.CompletedTask;
        }
    }
}