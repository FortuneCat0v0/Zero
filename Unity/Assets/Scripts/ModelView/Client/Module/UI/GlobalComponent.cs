using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent : Entity, IAwake
    {
        public Transform Global { get; set; }
        public Transform MainCamera { get; set; }
        public Transform UICamera { get; set; }
        public Transform YIUICanvasRoot { get; set; }
        public Transform Unit { get; set; }

        public Transform Effect { get; set; }
        public Transform Audio { get; set; }

        public GlobalConfig GlobalConfig { get; set; }
    }
}