namespace ET.Client
{
    [FriendOf(typeof(ClientPetComponent))]
    [EntitySystemOf(typeof(ClientPetComponent))]
    public static partial class ClientPetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientPetComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientPetComponent self)
        {
            self.Pets.Clear();
            self.Pets = null;
        }

        public static void AddSlimeFromMessage(this ClientPetComponent self, PetInfo petInfo)
        {
            Pet pet = self.AddChildWithId<Pet>(petInfo.Id);
            pet.FromMessage(petInfo);
            self.Pets.Add(pet.Id, pet);
        }

        public static void RemovePetById(this ClientPetComponent self, long petId)
        {
            if (!self.Pets.TryGetValue(petId, out EntityRef<Pet> entityRef))
            {
                Log.Error($"petId:{petId} not found");
                return;
            }

            Pet pet = entityRef;
            self.Pets.Remove(petId);
            pet?.Dispose();
        }

        public static void UpdatePet(this ClientPetComponent self, PetInfo petInfo)
        {
            if (!self.Pets.TryGetValue(petInfo.Id, out EntityRef<Pet> entityRef))
            {
                Log.Error($"petId:{petInfo.Id} not found");
                return;
            }

            Pet pet = entityRef;
            pet.FromMessage(petInfo);
        }

        public static void Clear(this ClientPetComponent self)
        {
            foreach (Pet pet in self.Pets.Values)
            {
                pet?.Dispose();
            }

            self.Pets.Clear();
        }
    }
}