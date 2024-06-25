using UnityEditor;

namespace MekaruStudios.MonsterCreator
{
    public class MonsterCreatorEditorWindow : EditorWindow
    {
        IMainWindow _mainWindow;

        [MenuItem("Tools/Mekaru Studios/Monster Creator")]
        public static void ShowWindow()
        {
            ServiceLocator.LoadDependencies();
            GetWindow(typeof(MonsterCreatorEditorWindow));
        }

        void OnDisable()
        {
            _mainWindow?.Destroy();
            ServiceLocator.DestroyInstance();
        }

        void OnGUI()
        {
            _mainWindow ??= ServiceLocator.Instance.Resolve<IMainWindow>();
            _mainWindow.Render(position.width);
        }
    }
}
