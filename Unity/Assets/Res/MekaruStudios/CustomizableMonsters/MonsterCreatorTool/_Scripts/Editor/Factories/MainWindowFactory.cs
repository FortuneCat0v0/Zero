using System;

namespace MekaruStudios.MonsterCreator
{
    public class MainWindowFactory : IMainWindowFactory
    {
        readonly IWindowFactory _windowFactory = new WindowFactory();

        public IMainWindow GetWindow(string type)
        {
            switch (type)
            {
                case "default":
                    var window1 = _windowFactory.GetWindow("packetList", .25f);
                    var window2 = _windowFactory.GetWindow("empty", .50f);
                    var window3 = _windowFactory.GetWindow("empty", .25f);

                    MainWindow mainWindow = A.MainWindow()
                        .With(window1)
                        .With(window2)
                        .With(window3);
                    
                    return mainWindow;
                default:
                    throw new ArgumentException("Invalid main window type: " + type, nameof(type));
            }
        }
    }
}
