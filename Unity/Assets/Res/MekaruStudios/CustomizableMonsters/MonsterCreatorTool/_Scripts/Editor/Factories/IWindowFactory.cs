namespace MekaruStudios.MonsterCreator
{
    public interface IWindowFactory
    {
        IWindow GetWindow(string typeName, float widthPercentage);
        IWindow GetWindow(string typeName);
    }
}
