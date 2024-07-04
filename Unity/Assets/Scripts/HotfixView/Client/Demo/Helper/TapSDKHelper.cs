using System;
using TapTap.Bootstrap;
using TapTap.Common;
using TapTap.Login;
using TapTap.AntiAddiction;
using TapTap.AntiAddiction.Model;

namespace ET.Client
{
    public static class TapSDKHelper
    {
        public static void Init()
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
    }
}