using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(ServerComponent))]
    [FriendOf(typeof(UIServerComponent))]
    [EntitySystemOf(typeof(UIServerComponent))]
    public static partial class UIServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIServerComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.ServerListNode = rc.Get<GameObject>("ServerListNode");
            self.ConfirmBtn = rc.Get<GameObject>("ConfirmBtn");

            self.ConfirmBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnConfirmBtn().Coroutine(); });

            self.ShowServerList().Coroutine();
        }

        private static async ETTask OnConfirmBtn(this UIServerComponent self)
        {
            bool isSelect = self.Scene().GetComponent<ServerComponent>().CurrentServerId != 0;

            if (!isSelect)
            {
                Log.Error("请先选择区服");
                return;
            }

            int errorCode = await LoginHelper.GetRoles(self.Scene());
            if (errorCode != ErrorCode.ERR_Success)
            {
                Log.Error(errorCode.ToString());
                return;
            }

            UIHelper.Create(self.Scene(), UIType.UIRole, UILayer.Mid).Coroutine();
            UIHelper.Remove(self.Scene(), UIType.UIServer);
        }

        private static async ETTask ShowServerList(this UIServerComponent self)
        {
            string assetsName = $"Assets/Bundles/UI/UIServer/UIServerItem.prefab";
            GameObject bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            foreach (GameServer gameServer in self.Scene().GetComponent<ServerComponent>().GameServers)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, self.ServerListNode.GetComponent<Transform>());
                self.AddChild<UIServerItem, GameObject, GameServer>(gameObject, gameServer);
            }
        }
    }
}