using MekaruStudios.CustomizableMonsters;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class UnitGUI : GUIDecorator, IWindowWidthObserver
    {
        readonly IPacketListController _packetListController;
        readonly IUnitContainerController _unitContainerController;

        float _windowWidth;

        public UnitGUI(IGUIComponent wrapped,
            IPacketListController packetListController,
            IUnitContainerController unitContainerController) : base(wrapped)
        {
            _packetListController = packetListController;
            _unitContainerController = unitContainerController;
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

            var monsterUnits = _packetListController.ActivePacketModel.GetMonsterUnitModels();
            MonsterCreatorStyling.RenderButtonsInGrid(
                monsterUnits,
                .25f,
                _windowWidth,
                new Rectangle(75, 75),
                item => new GUIContent(AssetPreview.GetAssetPreview(item.GetPrefab())),
                _unitContainerController.AddUnit
            );
        }
        public void UpdateWidth(float width) => _windowWidth = width;
    }
}
