using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public interface IFileSaver
    {
        void Save(GameObject objectToSave, string path);
    }
}
