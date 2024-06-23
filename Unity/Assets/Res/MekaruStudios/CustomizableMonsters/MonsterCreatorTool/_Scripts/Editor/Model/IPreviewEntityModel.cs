using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public interface IPreviewEntityModel
    {
        GameObject Get();
        void Create(GameObject prefab);
        void Destroy();
        void RegisterObserver(IPreviewEntityObserver observer);
        void RemoveRegister(IPreviewEntityObserver observer);
        void NotifyObservers();
    }
}
