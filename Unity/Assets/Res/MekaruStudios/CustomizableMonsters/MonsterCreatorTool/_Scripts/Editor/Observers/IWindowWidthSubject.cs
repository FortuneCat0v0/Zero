namespace MekaruStudios.MonsterCreator
{
    public interface IWindowWidthSubject
    {
        void RegisterObserver(IWindowWidthObserver observer);
        void UnregisterObserver(IWindowWidthObserver observer);
        void NotifyObservers(float width);
    }
}
