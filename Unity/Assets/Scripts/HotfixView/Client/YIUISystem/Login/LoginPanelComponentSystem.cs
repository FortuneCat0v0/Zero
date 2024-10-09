using System;
using YIUIFramework;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(LoginPanelComponent))]
    public static partial class LoginPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this LoginPanelComponent self)
        {
            self.u_ComAccountInput.text = PlayerPrefsHelper.GetString(PlayerPrefsHelper.Account, string.Empty);
            self.u_ComPasswordInput.text = PlayerPrefsHelper.GetString(PlayerPrefsHelper.Password, string.Empty);
        }

        [EntitySystem]
        private static void Destroy(this LoginPanelComponent self)
        {
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this LoginPanelComponent self)
        {
            await ETTask.CompletedTask;
            return true;
        }

        #region YIUIEvent开始

        private static void OnEventPasswordAction(this LoginPanelComponent self, string p1)
        {
            self.Password = p1;
        }

        private static void OnEventAccountAction(this LoginPanelComponent self, string p1)
        {
            self.Account = p1;
        }

        private static async ETTask OnEventLoginAction(this LoginPanelComponent self)
        {
            // var banId = YIUIMgrComponent.Inst.BanLayerOptionForever();
            // await LoginHelper.Login(self.Root(), self.Account, self.Password);
            // YIUIMgrComponent.Inst.RecoverLayerOptionForever(banId);
            await self.OnLogin(self.Account, self.Password, ELoginType.Normal);
        }

        #endregion YIUIEvent结束

        private static async ETTask OnTapTapBtn(this LoginPanelComponent self)
        {
            TapTapSDKHelper.LoginInit();
            TapTapSDKHelper.AntiAddictionInit(self.AntiAddictionCallback);

            string openid = await TapTapSDKHelper.Login();
            if (string.IsNullOrEmpty(openid))
            {
                Log.Error("TapTap账号登录失败");
                return;
            }

            self.TapTapOpenid = openid;

            TapTapSDKHelper.StartAntiAddiction(openid);
        }

        private static void AntiAddictionCallback(this LoginPanelComponent self, int code, string extra)
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

            if (code == 500)
            {
                Log.Debug("500 玩家未受到限制，正常进入游戏");
                self.OnLogin(self.TapTapOpenid, "TapTap", ELoginType.TapTap).Coroutine();
            }
            else if (code == 1000)
            {
                Log.Error("1000 退出防沉迷认证及检查，当开发者调用 Exit 接口时或用户认证信息无效时触发，游戏应返回到登录页");
            }
            else if (code == 1001)
            {
                Log.Error("1001 用户点击切换账号，游戏应返回到登录页");
            }
            else if (code == 1030)
            {
                Log.Error("1030 用户当前时间无法进行游戏，此时用户只能退出游戏或切换账号");
            }
            else if (code == 1050)
            {
                Log.Error("1050 用户无可玩时长，此时用户只能退出游戏或切换账号");
            }
            else if (code == 1100)
            {
                Log.Error("1100 当前用户因触发应用设置的年龄限制无法进入游戏");
            }
            else if (code == 1200)
            {
                Log.Error("1200 数据请求失败，游戏需检查当前设置的应用信息是否正确及判断当前网络连接是否正常");
            }
            else if (code == 9002)
            {
                Log.Error("9002 实名过程中点击了关闭实名窗，游戏可重新开始防沉迷认证");
            }
        }

        private static async ETTask OnLogin(this LoginPanelComponent self, string account, string password, ELoginType loginType)
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
                PlayerPrefsHelper.SetString(PlayerPrefsHelper.Password, password);
            }

            errorCode = await LoginHelper.GetServerInfos(self.Root());
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            Log.Error("登录成功，开始获取游戏服务器列表");
            await YIUIMgrComponent.Inst.ClosePanelAsync<LoginPanelComponent>(false, true);
            // await YIUIMgrComponent.Inst.Root.OpenPanelAsync<GameServerPanelComponent>();
        }
    }
}