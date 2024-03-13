using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UI))]
    public class UIRoleComponent: Entity, IAwake
    {
        public GameObject RoleListNode;
        public GameObject NameInputField;
        public GameObject CreateBtn;
        public GameObject DeleteBtn;
        public GameObject EnterGameBtn;
        public GameObject NameIF;

        // public List<UIRoleItemComponent> RoleList = new List<UIRoleItemComponent>();
    }
}