using System;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [Serializable]
    public class CosmeticSlot
    {
        [SerializeField]
        public string Type;
        
        [SerializeField]
        public string ParentBonePath;
        
        [SerializeField]
        public Vector3 Offset;

        [SerializeField]
        public Vector3 Rotation;
    }
}
