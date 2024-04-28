using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UI))]
    public class UIServerComponent: Entity, IAwake
    {
        public GameObject ServerListNode;
        public GameObject ConfirmBtn;
    }
}