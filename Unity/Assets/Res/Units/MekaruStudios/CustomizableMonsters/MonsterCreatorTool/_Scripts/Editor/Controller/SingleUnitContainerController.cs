using MekaruStudios.MonsterCreator;
using UnityEngine;

namespace MekaruStudios.CustomizableMonsters
{
    public class SingleUnitContainerController : IUnitContainerController
    {
        readonly IUnitContainerModel _unitContainer;
        readonly IPreviewEntityModel _previewEntityModel;
        
        public SingleUnitContainerController(IUnitContainerModel unitContainer, IPreviewEntityModel previewEntityModel)
        {
            _unitContainer = unitContainer;
            _previewEntityModel = previewEntityModel;
        }

        public void AddUnit(IUnitModel unit)
        {
            _unitContainer.Clear();
            _previewEntityModel.Create(unit.GetPrefab());
            _unitContainer.AddUnit(unit, _previewEntityModel.Get());
            unit.CosmeticModule.Init();
        }
    }
}
