using UnityEngine;

namespace MekaruStudios.MonsterCreator.Buttons
{
    public class WindowLoaderBtn : GUIDecorator
    {
        readonly string _windowTypeName;
        readonly string _label;

        public WindowLoaderBtn(
            IGUIComponent wrapped,
            string windowTypeName,
            string label
        ) : base(wrapped)
        {
            _windowTypeName = windowTypeName;
            _label = label;
        }

        public override void Render()
        {
            base.Render();

            if (GUILayout.Button(_label))
            {
                var factory = ServiceLocator.Instance.Resolve<IWindowFactory>();
                var mainWindow = ServiceLocator.Instance.Resolve<IMainWindow>();
                var window = factory.GetWindow(_windowTypeName);
                mainWindow.ReplaceWindow(window, 2);
            }
        }
    }
}
