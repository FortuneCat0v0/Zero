using System.Collections.Generic;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public interface IUnitContainerModel
    {
        void AddUnit(IUnitModel unitModel,GameObject gameObject);
        void RemoveUnit(IUnitModel unitModel);
        void Clear();
        bool IsUnitExist(IUnitModel unitModel);
        void RegisterObserver(IUnitContainerObserver observer);
        void RemoveObserver(IUnitContainerObserver observer);
        void Notify();
        List<IUnitModel> GetUnits();
        GameObject GetUnitGameObject(IUnitModel unitModel);

    }
}
