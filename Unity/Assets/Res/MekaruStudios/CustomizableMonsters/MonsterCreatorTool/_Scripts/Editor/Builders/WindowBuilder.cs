namespace MekaruStudios.MonsterCreator
{
    public class WindowBuilder
    {
        IGUIComponent _component; 
        float _widthPercentage = .25f;

        public WindowBuilder WithComponent(IGUIComponent component)
        {
            _component = component;
            return this;
        }
        public WindowBuilder WithWidthPercentage(float widthPercentage)
        {
            _widthPercentage = widthPercentage;
            return this;
        }
        IWindow Build()
        {
            return new Window(_widthPercentage, _component);
        }
        public static implicit operator Window(WindowBuilder builder)
        {
            return (Window)builder.Build();
        }
    }
}
