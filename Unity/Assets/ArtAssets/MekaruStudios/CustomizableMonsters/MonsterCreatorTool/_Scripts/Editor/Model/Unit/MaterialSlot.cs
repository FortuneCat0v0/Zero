using System;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [Serializable]
    public class MaterialSlot
    {
        [SerializeField]
        public string Name;
        
        [SerializeField]
        public string TransformPathToBindMaterial;

        [SerializeField]
        public MaterialBundle MaterialBundle;


    }
}
