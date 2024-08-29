using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIGMComponent : Entity, IAwake
    {
        public GameObject Go_Panel;
        public GameObject Img_Top;
        public GameObject Btn_Close;

        public Vector2 OriginalPanelPosition;
        public Vector2 OriginalPointPosition;
    }
}