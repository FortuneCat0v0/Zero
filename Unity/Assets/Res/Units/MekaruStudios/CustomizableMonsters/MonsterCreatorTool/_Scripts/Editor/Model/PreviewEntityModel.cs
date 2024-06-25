using System.Collections.Generic;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class PreviewEntityModel : IPreviewEntityModel 
    {
        GameObject _previewObject;
        readonly List<IPreviewEntityObserver> _observers = new List<IPreviewEntityObserver>();
        

        public GameObject Get()
        {
            return _previewObject;
        }
        public void Create(GameObject prefab)
        {
            Destroy();
            
            _previewObject = Object.Instantiate(prefab);
            NotifyObservers();
        }
        public void Destroy()
        {
            if(_previewObject != null)
                Object.DestroyImmediate(_previewObject);
        }
        public void RegisterObserver(IPreviewEntityObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveRegister(IPreviewEntityObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.UpdatePreviewEntity(_previewObject);
        }
    }
}
