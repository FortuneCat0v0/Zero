using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIMainComponent : Entity, IAwake
    {
        private EntityRef<UIJoystickComponent> uiJoystickComponent;

        public UIJoystickComponent UIJoystickComponent
        {
            get => this.uiJoystickComponent;
            set => this.uiJoystickComponent = value;
        }
    }
}