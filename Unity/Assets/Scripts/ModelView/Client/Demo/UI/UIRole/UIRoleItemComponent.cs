using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof (UIRoleComponent))]
    public class UIRoleItemComponent: Entity, IAwake<GameObject, Role>
    {
        public GameObject GameObject;
        public GameObject Btn;
        public GameObject NameText;

        public long RoleId;
    }
}