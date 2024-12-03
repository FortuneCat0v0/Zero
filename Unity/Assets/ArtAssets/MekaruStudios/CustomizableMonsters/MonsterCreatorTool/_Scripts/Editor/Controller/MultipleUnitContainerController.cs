using System.Collections.Generic;
using MekaruStudios.MonsterCreator;
using UnityEngine;

namespace MekaruStudios.CustomizableMonsters
{
    public class MultipleUnitContainerController : IUnitContainerController
    {
        readonly IUnitContainerModel _unitContainerModel;

        public MultipleUnitContainerController(IUnitContainerModel unitContainerModel)
        {
            _unitContainerModel = unitContainerModel;
        }
        public void AddUnit(IUnitModel unit)
        {
            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();

            if (IsRootNotExist())
                CreateRootGameObject(previewEntityModel);

            if (_unitContainerModel.IsUnitExist(unit))
                RemoveUnit(unit);
            else
                AddUnit(unit, previewEntityModel);
            
            previewEntityModel.NotifyObservers();
            return;

            bool IsRootNotExist() => previewEntityModel.Get().name != "root";
        }
        void AddUnit(IUnitModel unit, IPreviewEntityModel previewEntityModel)
        {
            var root = previewEntityModel.Get();
            var instantiatedUnit = Object.Instantiate(unit.GetPrefab(), root.transform);
            _unitContainerModel.AddUnit(unit, instantiatedUnit);
            unit.CosmeticModule.Init();
        }
        void RemoveUnit(IUnitModel unit)
        {
            var targetGameObject = _unitContainerModel.GetUnitGameObject(unit);
            Object.DestroyImmediate(targetGameObject);
            _unitContainerModel.RemoveUnit(unit);
        }
        void CreateRootGameObject(IPreviewEntityModel previewEntityModel)
        {
            var root = new GameObject("root");
            previewEntityModel.Create(root);
            previewEntityModel.Get().name = "root";
            Object.DestroyImmediate(root);
        }
    }
}
