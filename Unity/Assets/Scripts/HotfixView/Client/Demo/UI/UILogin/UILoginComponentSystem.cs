using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

            self.NormalBtn = rc.Get<GameObject>("NormalBtn");
            self.TapTapBtn = rc.Get<GameObject>("TapTapBtn");
            self.NormalLoginPanel = rc.Get<GameObject>("NormalLoginPanel");
            self.AccountIF = rc.Get<GameObject>("AccountIF");
            self.PasswordIF = rc.Get<GameObject>("PasswordIF");
            self.NormalLoginBtn = rc.Get<GameObject>("NormalLoginBtn");
            self.CloseNormalLoginPanelBtn = rc.Get<GameObject>("CloseNormalLoginPanelBtn");

            self.NormalBtn.GetComponent<Button>().AddListener(() => { self.NormalLoginPanel.SetActive(true); });
            self.TapTapBtn.GetComponent<Button>().AddListenerAsync(self.OnTapTapBtn);

            self.NormalLoginPanel.SetActive(false);
            self.AccountIF.GetComponent<TMP_InputField>().text = PlayerPrefsHelper.GetString(PlayerPrefsHelper.Account, string.Empty);
            self.PasswordIF.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString(PlayerPrefsHelper.Password, string.Empty);
            self.NormalLoginBtn.GetComponent<Button>().AddListenerAsync(self.OnNormalLoginBtn);
            self.CloseNormalLoginPanelBtn.GetComponent<Button>().AddListener(() => { self.NormalLoginPanel.SetActive(false); });

            TapTapSDKHelper.LoginInit();
            TapTapSDKHelper.AntiAddictionInit(self.AntiAddictionCallback);
        }

        private static async ETTask OnNormalLoginBtn(this UILoginComponent self)
        {
            string account = self.AccountIF.GetComponent<TMP_InputField>().text;
            string password = self.PasswordIF.GetComponent<TMP_InputField>().text;
            await self.OnLogin(account, password, ELoginType.Normal);
        }

        private static async ETTask OnTapTapBtn(this UILoginComponent self)
        {
            string openid = await TapTapSDKHelper.Login();
            if (string.IsNullOrEmpty(openid))
            {
                FlyTipComponent.Instance.ShowFlyTip("TapTap账号登录失败");
                return;
            }

            self.TapTapOpenid = openid;

            TapTapSDKHelper.StartAntiAddiction(openid);
        }

        private static void AntiAddictionCallback(this UILoginComponent self, int code, string extra)
        {
            // 防沉迷回调
            //500	LOGIN_SUCCESS	玩家未受到限制，正常进入游戏
            //1000	EXITED	退出防沉迷认证及检查，当开发者调用 Exit 接口时或用户认证信息无效时触发，游戏应返回到登录页
            //1001	SWITCH_ACCOUNT	用户点击切换账号，游戏应返回到登录页
            //1030	PERIOD_RESTRICT	用户当前时间无法进行游戏，此时用户只能退出游戏或切换账号
            //1050	DURATION_LIMIT	用户无可玩时长，此时用户只能退出游戏或切换账号
            //1100	AGE_LIMIT	当前用户因触发应用设置的年龄限制无法进入游戏
            //1200	INVALID_CLIENT_OR_NETWORK_ERROR	数据请求失败，游戏需检查当前设置的应用信息是否正确及判断当前网络连接是否正常
            //9002	REAL_NAME_STOP	实名过程中点击了关闭实名窗，游戏可重新开始防沉迷认证
            Log.Debug($"code: {code} error Message: {extra}");

            if (code == 500)
            {
                FlyTipComponent.Instance.ShowFlyTip("500 玩家未受到限制，正常进入游戏");
                self.OnLogin(self.TapTapOpenid, "TapTap", ELoginType.TapTap).Coroutine();
            }
            else if (code == 1000)
            {
                FlyTipComponent.Instance.ShowFlyTip("1000 退出防沉迷认证及检查，当开发者调用 Exit 接口时或用户认证信息无效时触发，游戏应返回到登录页");
            }
            else if (code == 1001)
            {
                FlyTipComponent.Instance.ShowFlyTip("1001 用户点击切换账号，游戏应返回到登录页");
            }
            else if (code == 1030)
            {
                FlyTipComponent.Instance.ShowFlyTip("1030 用户当前时间无法进行游戏，此时用户只能退出游戏或切换账号");
            }
            else if (code == 1050)
            {
                FlyTipComponent.Instance.ShowFlyTip("1050 用户无可玩时长，此时用户只能退出游戏或切换账号");
            }
            else if (code == 1100)
            {
                FlyTipComponent.Instance.ShowFlyTip("1100 当前用户因触发应用设置的年龄限制无法进入游戏");
            }
            else if (code == 1200)
            {
                FlyTipComponent.Instance.ShowFlyTip("1200 数据请求失败，游戏需检查当前设置的应用信息是否正确及判断当前网络连接是否正常");
            }
            else if (code == 9002)
            {
                FlyTipComponent.Instance.ShowFlyTip("9002 实名过程中点击了关闭实名窗，游戏可重新开始防沉迷认证");
            }
        }

        private static async ETTask OnLogin(this UILoginComponent self, string account, string password, ELoginType loginType)
        {
            // 弹出登录中UI,放置重复发送
            int errorCode = await LoginHelper.LoginAccount(self.Root(), account, password, loginType);
            // 关闭登录中UI
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            if (loginType == ELoginType.Normal)
            {
                PlayerPrefsHelper.SetString(PlayerPrefsHelper.Account, account);
                PlayerPrefs.SetString(PlayerPrefsHelper.Password, password);
            }

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