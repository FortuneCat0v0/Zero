namespace MekaruStudios.MonsterCreator
{
    public interface IMainWindow
    {
        void Append(IWindow window);
        void Render(float width);
        void ReplaceWindow(IWindow window, int index);
        void Destroy();
        IWindow GetWindow(int index);

    }
}
