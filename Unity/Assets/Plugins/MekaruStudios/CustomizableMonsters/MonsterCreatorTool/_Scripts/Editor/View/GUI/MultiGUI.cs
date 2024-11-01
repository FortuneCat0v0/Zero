using System.Collections.Generic;
using System.Linq;
using MekaruStudios.CustomizableMonsters;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{

    public class MultiGUI : GUIDecorator, IWindowWidthObserver
    {
        readonly IUnitContainerController _unitContainerController;
        readonly IPacketListController _packetListController;

        IUnitModel _selectedUnitModel;
        IEnumerable<UnitModel> _loadedUnitModels;

        Vector2 _scrollPos;
        float _windowWidth;

        public MultiGUI(IGUIComponent wrapped,
            IPacketListController packetListController,
            IUnitContainerController containerController) : base(wrapped)
        {
            _packetListController = packetListController;
            _unitContainerController = containerController;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.RegisterObserver(this);
        }

        public override void OnExit()
        {
            base.OnExit();
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.UnregisterObserver(this);
        }


        public override void Render()
        {
            base.Render();

            _scrollPos = GUILayout.BeginScrollView(_scrollPos);

            var units = _packetListController.ActivePacketModel.GetMonsterUnitModels();
            var unitCategoryNames = units.Select(unit => unit.Category).Distinct();
            foreach (var categoryName in unitCategoryNames)
            {
                if (GUILayout.Button(categoryName))
                {
                    _loadedUnitModels = units.Where(u => u.Category == categoryName);
                    _selectedUnitModel = null;
                }
            }

            if (_loadedUnitModels == null)
                return;

            MonsterCreatorStyling.RenderButtonsInGrid(
                _loadedUnitModels,
                .25f,
                _windowWidth,
                new Rectangle(75, 75),
                item => new GUIContent(AssetPreview.GetAssetPreview(item.GetPrefab())),
                OnSelectUnitModel
            );

            if (_selectedUnitModel == null)
                return;

            MonsterCreatorStyling.RenderButtonsInGrid(
                _selectedUnitModel.CosmeticModule.GetCosmetics(),
                .25f,
                _windowWidth,
                new Rectangle(75f, 75f),
                cosmetic => CreateGUIContent(cosmetic.Prefab),
                cosmetic => _selectedUnitModel.CosmeticModule.BindCosmetic(cosmetic)
            );

            var materialSlot = _selectedUnitModel.GetMaterialSlot("base");
            MonsterCreatorStyling.RenderButtonsInGrid(
                materialSlot.MaterialBundle.Materials,
                .25f,
                _windowWidth,
                new Rectangle(75f, 75f),
                mat => new GUIContent(AssetPreview.GetAssetPreview(mat)),
                mat => _selectedUnitModel.BindMaterial(mat, materialSlot)
            );

            GUILayout.EndScrollView();
        }
        void OnSelectUnitModel(IUnitModel unit)
        {
            _unitContainerController.AddUnit(unit);
            _selectedUnitModel = unit;
        }
        static GUIContent CreateGUIContent(Object prefab)
        {
            return new GUIContent(AssetPreview.GetAssetPreview(prefab));
        }
        public void UpdateWidth(float width)
        {
            _windowWidth = width;
        }
    }
}
