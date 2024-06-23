namespace MekaruStudios.MonsterCreator
{
    public class MainWindowBuilder 
    {
        readonly IMainWindow _mainWindow = new MainWindow();
        
        public MainWindowBuilder With(IWindow window)
        {
            _mainWindow.Append(window);
            return this;
        }

        public IMainWindow Build()
        {
            return _mainWindow;
        }

        public static implicit operator MainWindow(MainWindowBuilder builder)
        {
            return (MainWindow)builder.Build();
        }

    }
}
