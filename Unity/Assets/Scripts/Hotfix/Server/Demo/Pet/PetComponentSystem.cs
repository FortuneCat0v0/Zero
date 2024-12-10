namespace ET.Server
{
    [FriendOf(typeof(PetComponent))]
    [EntitySystemOf(typeof(PetComponent))]
    public static partial class PetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PetComponent self)
        {
            self.Pets.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this PetComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                if (entity is Pet pet)
                {
                    self.Pets.Add(pet.Id, pet);
                }
            }
        }

        public static void GetSlimes(this PetComponent self, ListComponent<Pet> petList)
        {
            foreach (Pet slime in self.Pets.Values)
            {
                petList.Add(slime);
            }
        }

        public static Pet GetSlime(this PetComponent self, long petId)
        {
            self.Pets.TryGetValue(petId, out EntityRef<Pet> entityRef);
            return entityRef;
        }

        public static void AddSlime(this PetComponent self, Pet pet)
        {
            if (pet.Parent != self)
            {
                self.AddChild(pet);
            }

            if (self.Pets.ContainsKey(pet.Id))
            {
                return;
            }

            self.Pets.Add(pet.Id, pet);
            PetNoticeHelper.SyncPetInfo(self.Parent.GetParent<Unit>(), pet, PetOpType.Add);
        }

        public static bool RemoveSlime(this PetComponent self, long petId)
        {
            if (!self.Pets.TryGetValue(petId, out EntityRef<Pet> entityRef))
            {
                return false;
            }

            Pet pet = entityRef;
            self.Pets.Remove(petId);
            PetNoticeHelper.SyncPetInfo(self.Parent.GetParent<Unit>(), pet, PetOpType.Remove);
            pet?.Dispose();

            return true;
        }
    }
}