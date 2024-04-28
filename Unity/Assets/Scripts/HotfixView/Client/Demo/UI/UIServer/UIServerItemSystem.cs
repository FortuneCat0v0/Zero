using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(GameServer))]
    [FriendOf(typeof(GameServerComponent))]
    [FriendOf(typeof(UIServerItem))]
    [EntitySystemOf(typeof(UIServerItem))]
    public static partial class UIServerItemSystem
    {
        [EntitySystem]
        private static void Awake(this UIServerItem self, GameObject gameObject, GameServer server)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.NameText = rc.Get<GameObject>("NameText");
            self.Btn = rc.Get<GameObject>("Btn");

            self.NameText.GetComponent<TMP_Text>().text = server.ServerName;
            self.ServerId = server.Id;

            self.Btn.GetComponent<Button>().onClick.AddListener(self.OnBtn);
        }

        private static void OnBtn(this UIServerItem self)
        {
            self.Root().GetComponent<GameServerComponent>().CurrentServerId = int.Parse(self.ServerId.ToString());
        }
    }
}