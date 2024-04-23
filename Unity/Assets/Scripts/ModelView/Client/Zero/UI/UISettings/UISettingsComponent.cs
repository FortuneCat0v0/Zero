using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UISettingsComponent : Entity, IAwake
    {
        public GameObject CloseBtn;
    }
}