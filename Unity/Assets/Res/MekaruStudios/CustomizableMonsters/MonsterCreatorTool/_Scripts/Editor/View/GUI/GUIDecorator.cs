namespace MekaruStudios.MonsterCreator
{
    public abstract class GUIDecorator : IGUIComponent
    {
        protected readonly IGUIComponent _wrapped;

        protected GUIDecorator(IGUIComponent wrapped)
        {
            _wrapped = wrapped;
        }
        
        public virtual void Render()
        {
            _wrapped?.Render();
        }

        public virtual void OnEnter()
        {
            _wrapped?.OnEnter();
        }

        public virtual void OnExit()
        {
            _wrapped?.OnExit();
        }



    }
}
