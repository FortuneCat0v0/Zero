using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(ServerComponent))]
    [FriendOf(typeof(UIServerItemComponent))]
    [EntitySystemOf(typeof(UIServerItemComponent))]
    public static partial class UIServerItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIServerItemComponent self, GameObject gameObject, GameServer server)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.NameText = rc.Get<GameObject>("NameText");
            self.Btn = rc.Get<GameObject>("Btn");

            self.NameText.GetComponent<Text>().text = server.ServerName;
            self.ServerId = server.Id;

            self.Btn.GetComponent<Button>().onClick.AddListener(self.OnBtn);
        }

        private static void OnBtn(this UIServerItemComponent self)
        {
            self.Root().GetComponent<ServerComponent>().CurrentServerId = int.Parse(self.ServerId.ToString());
        }
    }
}