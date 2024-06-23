using System.Collections.Generic;

namespace MekaruStudios.MonsterCreator
{
    public interface IWindow
    {
        float WidthPercentage { get; set; }
        void Render();
        IGUIComponent GetComponent();
        void OnEnter() { }
        void OnExit() { }
    }
}
