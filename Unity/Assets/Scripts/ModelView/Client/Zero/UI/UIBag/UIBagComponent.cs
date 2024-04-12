using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIBagComponent : Entity, IAwake
    {
        public GameObject ItemTypeTG;
        public GameObject AllToggle;
        public GameObject EquipToggle;
        public GameObject MaterialToggle;
        public GameObject ConsumeToggle;
        public GameObject UICommonItemsRoot;

        public List<UICommonItem> UICommonItems { get; set; } = new();
        public int CurrentType;
    }
}