using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent : Entity, IAwake
    {
        public Transform Global { get; set; }
        public Transform MainCamera { get; set; }

        public GameObject Mask { get; set; }
        public Transform UICamera { get; set; }
        public Transform YIUICanvasRoot { get; set; }
        public Transform UnitRoot { get; set; }
        public Transform EffectRoot { get; set; }
        public Transform AudioRoot { get; set; }
        public GlobalConfig GlobalConfig { get; set; }
    }
}