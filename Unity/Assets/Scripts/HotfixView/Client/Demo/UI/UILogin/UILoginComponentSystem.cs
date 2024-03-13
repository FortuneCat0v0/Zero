using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILoginComponent))]
    [FriendOf(typeof(UILoginComponent))]
    public static partial class UILoginComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.AccountIF = rc.Get<GameObject>("AccountIF");
            self.PasswordIF = rc.Get<GameObject>("PasswordIF");
            self.LoginBtn = rc.Get<GameObject>("LoginBtn");

            self.LoginBtn.GetComponent<Button>().AddListenerAsync(self.OnLoginBtn);

            self.AccountIF.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Zero_Account", string.Empty);
            self.PasswordIF.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Zero_Password", string.Empty);
        }

        private static async ETTask OnLoginBtn(this UILoginComponent self)
        {
            string accountName = self.AccountIF.GetComponent<TMP_InputField>().text;
            string password = self.PasswordIF.GetComponent<TMP_InputField>().text;
            // 弹出登录中UI,放置重复发送
            int errorCode = await LoginHelper.LoginAccount(self.Root(), accountName, password);
            // 关闭登录中UI
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            PlayerPrefs.SetString("Zero_Account", accountName);
            PlayerPrefs.SetString("Zero_Password", password);

            errorCode = await LoginHelper.GetServerInfos(self.Root());
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            UIHelper.Create(self.Scene(), UIType.UIServer, UILayer.Mid).Coroutine();
            UIHelper.Remove(self.Scene(), UIType.UILogin);
        }
    }
}