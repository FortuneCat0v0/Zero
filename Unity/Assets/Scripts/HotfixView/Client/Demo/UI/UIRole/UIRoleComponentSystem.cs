using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(RoleComponent))]
    [FriendOf(typeof(UIRoleItemComponent))]
    [FriendOf(typeof(UIRoleComponent))]
    [EntitySystemOf(typeof(UIRoleComponent))]
    public static partial class UIRoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIRoleComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.RoleListNode = rc.Get<GameObject>("RoleListNode");
            self.CreateBtn = rc.Get<GameObject>("CreateBtn");
            self.DeleteBtn = rc.Get<GameObject>("DeleteBtn");
            self.EnterGameBtn = rc.Get<GameObject>("EnterGameBtn");
            self.NameIF = rc.Get<GameObject>("NameIF");

            self.CreateBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnCreateBtn().Coroutine(); });
            self.DeleteBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnDeleteBtn().Coroutine(); });
            self.EnterGameBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnEnterGameBtn().Coroutine(); });

            self.UpdateRoleList().Coroutine();
        }

        private static async ETTask OnCreateBtn(this UIRoleComponent self)
        {
            string name = self.NameIF.GetComponent<TMP_InputField>().text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("Name is null");
                return;
            }

            int errorCode = await LoginHelper.CreateRole(self.Scene(), name);
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
                return;
            }

            self.UpdateRoleList().Coroutine();
            await ETTask.CompletedTask;
        }

        private static async ETTask OnDeleteBtn(this UIRoleComponent self)
        {
            if (self.Scene().GetComponent<RoleComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }

            int errorCode = await LoginHelper.DeleteRole(self.Scene());
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
                return;
            }

            self.UpdateRoleList().Coroutine();

            await ETTask.CompletedTask;
        }

        private static async ETTask OnEnterGameBtn(this UIRoleComponent self)
        {
            if (self.Scene().GetComponent<RoleComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择角色");
                return;
            }

            int errorCode = await LoginHelper.GetRealmKey(self.Scene());
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("好好");

            errorCode = await LoginHelper.EnterGame(self.Scene(), PlayerPrefs.GetString("Account", string.Empty),
                PlayerPrefs.GetString("Password", string.Empty));
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
                return;
            }

            UIHelper.Remove(self.Scene(), UIType.UIRole);
            await ETTask.CompletedTask;
        }

        private static async ETTask UpdateRoleList(this UIRoleComponent self)
        {
            RoleComponent roleComponent = self.Root().GetComponent<RoleComponent>();
            string assetsName = $"Assets/Bundles/UI/UIRole/UIRoleItem.prefab";
            GameObject bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            int num = 0;
            for (int i = 0; i < roleComponent.Roles.Count; i++)
            {
                if (i < self.UIRoleItemComponents.Count)
                {
                    UIRoleItemComponent uiRoleItemComponent = self.UIRoleItemComponents[i];
                    uiRoleItemComponent.UpdateInfo(self.Scene().GetComponent<RoleComponent>().Roles[i]);
                }
                else
                {
                    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, self.RoleListNode.GetComponent<Transform>());
                    UIRoleItemComponent uiRoleItemComponent =
                            self.AddChild<UIRoleItemComponent, GameObject, Role>(gameObject, roleComponent.Roles[i]);
                    self.UIRoleItemComponents.Add(uiRoleItemComponent);
                }

                num++;
            }

            for (int i = num; i < self.UIRoleItemComponents.Count; i++)
            {
                UIRoleItemComponent uiRoleItemComponent = self.UIRoleItemComponents[i];
                uiRoleItemComponent.GameObject.SetActive(false);
            }

            await ETTask.CompletedTask;
        }
    }
}