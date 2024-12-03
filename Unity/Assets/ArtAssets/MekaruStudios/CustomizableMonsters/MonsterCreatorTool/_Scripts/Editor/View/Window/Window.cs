namespace MekaruStudios.MonsterCreator
{
    public class Window : IWindow
    {
        public float WidthPercentage { get; set; }
        readonly IGUIComponent _component;

        public Window(float widthPercentage, IGUIComponent component)
        {
            _component = component;
            WidthPercentage = widthPercentage;
        }

        public void OnEnter() => _component?.OnEnter();
        public void OnExit() => _component?.OnExit();

        public void Render() => _component.Render();
        public IGUIComponent GetComponent()
        {
            return _component;
        }
        public float GetWidthPercentage()
        {
            return WidthPercentage;
        }
    }
}
