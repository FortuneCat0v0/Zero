using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class CosmeticSlotAndPrefab
    {
        public CosmeticSlot Slot;
        public GameObject CosmeticPrefab;

        public CosmeticSlotAndPrefab(CosmeticSlot slot, GameObject cosmeticPrefab)
        {
            Slot = slot;
            CosmeticPrefab = cosmeticPrefab;
        }
    }
}
