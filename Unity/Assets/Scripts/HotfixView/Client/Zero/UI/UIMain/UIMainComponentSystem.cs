using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMainComponent))]
    [FriendOf(typeof(UIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.GoldText = rc.Get<GameObject>("GoldText");
            self.GMBtn = rc.Get<GameObject>("GMBtn");
            self.MatchBtn = rc.Get<GameObject>("MatchBtn");

            self.GMBtn.GetComponent<Button>().AddListenerAsync(self.OnGMBtn);
            self.MatchBtn.GetComponent<Button>().AddListenerAsync(self.OnMatchBtn);

            // self.GoldText.GetComponent<TMP_Text>().text = $"金币：{UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponent>()
            //         .GetAsLong(NumericType.Gold)}";
        }

        private static async ETTask OnGMBtn(this UIMainComponent self)
        {
            // await UIHelper.Create(self.Scene(), UIType.UIGM, UILayer.Mid);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnMatchBtn(this UIMainComponent self)
        {
            // G2C_Match response = await self.Root().GetComponent<ClientSenderComponent>().Call(new C2G_Match()) as G2C_Match;
            await ETTask.CompletedTask;
        }
    }
}