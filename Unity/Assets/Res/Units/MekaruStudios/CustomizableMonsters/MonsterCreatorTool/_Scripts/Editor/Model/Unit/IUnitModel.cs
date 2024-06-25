using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public interface IUnitModel
    {
        CosmeticModule CosmeticModule { get; }

        GameObject GetPrefab();
        MaterialSlot GetMaterialSlot(string slotName);
        void BindMaterial(Material mat, MaterialSlot slot);
    }
}
