using System;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [Serializable]
    public class Cosmetic
    {
        [SerializeField]
        public GameObject Prefab;

        [SerializeField]
        public string Type;

        public Cosmetic(GameObject prefab, string type)
        {
            Prefab = prefab;
            Type = type;
        }
    }
}
