using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class MaterialGUI : IGUIComponent, IUnitContainerObserver, IWindowWidthObserver
    {
        List<IUnitModel> _monsterUnitModels = new List<IUnitModel>();
        readonly IUnitContainerModel _unitContainerModel;
        readonly string _slotName;
        readonly bool _usePreviewGUI;

        Vector2 _scrollPos;
        float _windowWidth;

        public MaterialGUI(IUnitContainerModel unitContainerModel, string slotName, bool usePreviewGUI = false)
        {
            _unitContainerModel = unitContainerModel;
            _unitContainerModel.RegisterObserver(this);
            _unitContainerModel.Notify();

            _slotName = slotName;
            _usePreviewGUI = usePreviewGUI;
        }


        public void Render()
        {
            if (_monsterUnitModels.Count == 0)
                return;

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            foreach (var unit in _monsterUnitModels)
            {
                var materialSlot = unit.GetMaterialSlot(_slotName);
                MonsterCreatorStyling.RenderButtonsInGrid(
                    materialSlot.MaterialBundle.Materials,
                    .25f,
                    _windowWidth,
                    new Rectangle(75, 75),
                    GetGUIContent,
                    mat => BindMaterial(mat, unit)
                );
            }

            EditorGUILayout.EndScrollView();

        }

        GUIContent GetGUIContent(Material material)
        {
            if (material == null)
                return new GUIContent("None");

            return _usePreviewGUI
                ? new GUIContent(AssetPreview.GetAssetPreview(material))
                : new GUIContent(material.mainTexture);
        }
        void BindMaterial(Material material, IUnitModel unitModel)
        {

            var materialSlot = unitModel.GetMaterialSlot(_slotName);
            _monsterUnitModels[0].BindMaterial(material, materialSlot);

        }
        public void OnEnter()
        {
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.RegisterObserver(this);
        }
        public void OnExit()
        {
            _unitContainerModel.RemoveObserver(this);
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.UnregisterObserver(this);
        }
        public void UpdateMonsterUnitStorage(List<IUnitModel> monsterUnitModels)
        {
            _monsterUnitModels = monsterUnitModels;
        }
        public void UpdateWidth(float width)
        {
            _windowWidth = width;
        }
    }
}
