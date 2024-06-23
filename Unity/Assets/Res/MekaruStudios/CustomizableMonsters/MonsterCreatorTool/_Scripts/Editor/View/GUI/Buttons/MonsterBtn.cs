using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class MonsterBtn : GUIDecorator
    {
        public MonsterBtn(IGUIComponent wrapped) : base(wrapped) { }

        public override void Render()
        {
            base.Render();

            if (GUILayout.Button("Select Monster Type"))
            {
                var factory = ServiceLocator.Instance.Resolve<IWindowFactory>();
                var mainWindow = ServiceLocator.Instance.Resolve<IMainWindow>();
                var window = factory.GetWindow("monsterUnitSelection", .25f);
                mainWindow.ReplaceWindow(window, 2);
            }
        }
    }
}
