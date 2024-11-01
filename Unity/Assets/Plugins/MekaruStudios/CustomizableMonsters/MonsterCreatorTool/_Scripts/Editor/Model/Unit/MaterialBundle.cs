using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [CreateAssetMenu(menuName = "MekaruStudios/MonsterCreator/Storage/Material", fileName = "MaterialBundle", order = 0)]
    public class MaterialBundle : ScriptableObject
    {
        [SerializeField]
        public Material[] Materials;
    }
}
