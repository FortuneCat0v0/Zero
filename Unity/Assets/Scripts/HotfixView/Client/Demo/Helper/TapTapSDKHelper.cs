using System;
using TapTap.AntiAddiction;
using TapTap.AntiAddiction.Model;
using TapTap.Common;
using TapTap.Login;

namespace ET.Client
{
    public static class TapTapSDKHelper
    {
        public static void LoginInit()
        {
            TapLogin.Init("ar3vmzxoxl8h3k9jyl");
        }

        public static async ETTask<string> Login()
        {
            try
            {
                // 在 iOS、Android 系统下，会唤起 TapTap 客户端或以 WebView 方式进行登录
                // 在 Windows、macOS 系统下显示二维码（默认）和跳转链接（需配置）
                var accessToken = await TapLogin.Login();
                Log.Debug($"TapTap 登录成功 accessToken: {accessToken.ToJson()}");
            }
            catch (Exception e)
            {
                if (e is TapException tapError) // using TapTap.Common
                {
                    Log.Debug($"encounter exception:{tapError.code} message:{tapError.message}");
                    if (tapError.code == (int)TapErrorCode.ERROR_CODE_BIND_CANCEL) // 取消登录
                    {
                        Log.Debug("登录取消");
                    }
                }
            }

            // 获取 TapTap Profile  可以获得当前用户的一些基本信息，例如名称、头像。
            var profile = await TapLogin.FetchProfile();
            Log.Debug($"TapTap 登录成功 profile: {profile.ToJson()}");

            return profile.openid;
        }

        public static void LoginOut()
        {
            TapLogin.Logout();
        }

        public static void AntiAddictionInit(Action<int, string> callback)
        {
            AntiAddictionConfig config = new()
            {
                gameId = "ar3vmzxoxl8h3k9jyl", // TapTap 开发者中心对应 Client ID
                showSwitchAccount = false, // 是否显示切换账号按钮
                useAgeRange = true // 是否使用年龄段信息
            };
            //设置配置及回调，callback 为开发者实现的自定义防沉迷回调对象
            AntiAddictionUIKit.Init(config);
            AntiAddictionUIKit.SetAntiAddictionCallback(callback);
            //500	LOGIN_SUCCESS	玩家未受到限制，正常进入游戏
            //1000	EXITED	退出防沉迷认证及检查，当开发者调用 Exit 接口时或用户认证信息无效时触发，游戏应返回到登录页
            //1001	SWITCH_ACCOUNT	用户点击切换账号，游戏应返回到登录页
            //1030	PERIOD_RESTRICT	用户当前时间无法进行游戏，此时用户只能退出游戏或切换账号
            //1050	DURATION_LIMIT	用户无可玩时长，此时用户只能退出游戏或切换账号
            //1100	AGE_LIMIT	当前用户因触发应用设置的年龄限制无法进入游戏
            //1200	INVALID_CLIENT_OR_NETWORK_ERROR	数据请求失败，游戏需检查当前设置的应用信息是否正确及判断当前网络连接是否正常
            //9002	REAL_NAME_STOP	实名过程中点击了关闭实名窗，游戏可重新开始防沉迷认证
        }

        public static void StartAntiAddiction(string openid)
        {
            AntiAddictionUIKit.StartupWithTapTap(openid);
        }

        public static void ExitAntiAddiction()
        {
            AntiAddictionUIKit.Exit();
        }
    }
}