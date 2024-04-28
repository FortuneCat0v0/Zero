using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UICommonItem : Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject ClickBtn;
        public GameObject DragEvent;
        public GameObject QualityImg;
        public GameObject IconImg;
        public GameObject NumText;
        public GameObject NameText;
        public GameObject HighlightImg;
        public GameObject LockItemImg;
        public GameObject UpTipImg;
        public GameObject LockCellImg;
        public GameObject ItemTipBtn;

        private EntityRef<Item> item;

        public Item Item
        {
            get => this.item;
            set => this.item = value;
        }
    }
}