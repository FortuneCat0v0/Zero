using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    
    [CreateAssetMenu(menuName = "MekaruStudios/MonsterCreator/Storage/Cosmetic", fileName = "CosmeticStorage", order = 0)]
    public class CosmeticStorage : ScriptableObject
    {
        [Serializable]
        struct TypeAndPrefabs
        {
            [SerializeField]
            public string Type;

            [SerializeField]
            public GameObject[] Prefabs;
        }

        [SerializeField]
        TypeAndPrefabs[] _cosmeticTypesAndPrefabs;


        /* TODO this is a terrible implementation,
         Now this will load cosmetics every time a unit model clicked*/
        public List<Cosmetic> GetCosmetics()
        {
            return (
                from typeAndPrefabs in _cosmeticTypesAndPrefabs
                from prefab in typeAndPrefabs.Prefabs 
                select new Cosmetic(prefab, typeAndPrefabs.Type)
                ).ToList();
        }


    }

}
