using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Role))]
    [FriendOf(typeof (RoleComponent))]
    [FriendOf(typeof (UIRoleItemComponent))]
    [EntitySystemOf(typeof (UIRoleItemComponent))]
    public static partial class UIRoleItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIRoleItemComponent self, GameObject gameObject, Role role)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.GameObject = gameObject;
            self.Btn = rc.Get<GameObject>("Btn");
            self.NameText = rc.Get<GameObject>("NameText");

            self.UpdateInfo(role);

            self.Btn.GetComponent<Button>().onClick.AddListener(self.OnBtn);
        }

        private static void OnBtn(this UIRoleItemComponent self)
        {
            self.Scene().GetComponent<RoleComponent>().CurrentRoleId = self.RoleId;
        }

        public static void UpdateInfo(this UIRoleItemComponent self, Role role)
        {
            self.NameText.GetComponent<TMP_Text>().text = role.Name;
            self.GameObject.SetActive(true);
            self.RoleId = role.Id;
        }
    }
}