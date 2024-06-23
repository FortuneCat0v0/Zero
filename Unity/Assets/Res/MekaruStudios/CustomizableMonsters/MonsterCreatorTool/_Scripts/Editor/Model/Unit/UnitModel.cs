using System;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [CreateAssetMenu(menuName = "MekaruStudios/MonsterCreator/MonsterUnit", fileName = "MonsterUnit", order = 0)]
    public class UnitModel : ScriptableObject, IUnitModel
    {
        [SerializeField]
        GameObject _prefab;
        
        [SerializeField]
        CosmeticModule _cosmeticModule;
        
        [SerializeField]
        MaterialSlot[] MaterialSlots;

        
        [SerializeField]
        public string Category = "";
        public CosmeticModule CosmeticModule => _cosmeticModule;


        public GameObject GetPrefab() => _prefab;

        public void BindMaterial(Material material, MaterialSlot slot)
        {
            MaterialBinder.Bind(material, slot.TransformPathToBindMaterial);
        }

        public MaterialSlot GetMaterialSlot(string slotName)
        {
            foreach (var slot in MaterialSlots)
            {
                if (slot.Name == slotName)
                    return slot;
            }
            throw new ArgumentException("Given slot name not exist in slots");
        }

    }
}
