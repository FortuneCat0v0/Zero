using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class UnitContainerModel : IUnitContainerModel
    {
        readonly Dictionary<IUnitModel, GameObject> _unitModels = new Dictionary<IUnitModel, GameObject>();
        readonly List<IUnitContainerObserver> _observers = new List<IUnitContainerObserver>();

        public void AddUnit(IUnitModel unitModel, GameObject gameObject)
        {
            if (_unitModels.ContainsKey(unitModel))
                return;

            _unitModels.Add(unitModel, gameObject);
            Notify();
        }
        public void RemoveUnit(IUnitModel unitModel)
        {
            _unitModels.Remove(unitModel);
            Notify();
        }
        public GameObject GetUnitGameObject(IUnitModel unitModel)
        {
            return _unitModels.TryGetValue(unitModel, out var correspondedGameObject) 
                ? correspondedGameObject 
                : null;
        }
        public void Clear()
        {
            _unitModels.Clear();
            Notify();
        }
        public bool IsUnitExist(IUnitModel unitModel) => _unitModels.ContainsKey(unitModel);
        public void RegisterObserver(IUnitContainerObserver observer) => _observers.Add(observer);
        public void RemoveObserver(IUnitContainerObserver observer) => _observers.Remove(observer);
        public void Notify()
        {
            foreach (var observer in _observers)
                observer.UpdateMonsterUnitStorage(_unitModels.Keys.ToList());
        }
        public List<IUnitModel> GetUnits()
        {
            return _unitModels.Keys.ToList();
        }
    }
}
