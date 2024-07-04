using System;
using TapTap.Bootstrap;
using TapTap.Common;
using TapTap.Login;

namespace ET.Client
{
    public static class TapSDKHelper
    {
        /// <summary>
        /// SDK 初始化
        /// </summary>
        public static void Init()
        {
            Log.Debug("Tap Bootstrap.Init");
            var config = new TapConfig.Builder()
                    .ClientID("ar3vmzxoxl8h3k9jyl") // 必须，开发者中心对应 Client ID
                    .ClientToken("iL1tk8TST49ebHXRYjblVBZQsFLrDHnnWfbQyWmT") // 必须，开发者中心对应 Client Token
                    .ServerURL("https://ar3vmzxo.cloud.tds1.tapapis.cn") // 必须，开发者中心 > 你的游戏 > 游戏服务 > 基本信息 > 域名配置 > API
                    .RegionType(RegionType.CN) // 非必须，CN 表示中国大陆，IO 表示其他国家或地区
                    .ConfigBuilder();
            TapBootstrap.Init(config);
        }

        /// <summary>
        /// 检查登录状态
        /// </summary>
        public static async ETTask CheckLogin()
        {
            // SDK 会在本地缓存当前用户的登录信息，所以如果一个玩家在游戏内登录之后，下次启动用户通过调用如下方法可以得到之前登录的账户实例。
            // 缓存不会自动清除。此时玩家无需再次登录，可以直接进入游戏，实现静默登录。
            // 如果玩家在游戏内进行了登出或者玩家手动清除了游戏的存储数据，则本地缓存的登录信息也会被删除，下次进入游戏时调用如下方法会返回一
            // 个 null 对象，玩家需要登录之后再进入游戏。

            var currentUser = await TDSUser.GetCurrent();
            if (null == currentUser)
            {
                Log.Debug("当前未登录");
                // 开始登录
            }
            else
            {
                Log.Debug("已登录");
                // 进入游戏
            }
        }

        /// <summary>
        /// 一键完成 TapTap 登录
        /// </summary>
        public static async ETTask<string> Login()
        {
            // var currentUser = TDSUser.GetCurrent();
            // Log.Debug(null == currentUser ? "TapTap 当前未登录" : "TapTap 已登录");

            try
            {
                // 在 iOS、Android 系统下会唤起 TapTap 客户端或以 WebView 方式进行登录
                // 在 Windows、macOS 系统下显示二维码（默认）和跳转链接（需配置）
                var tdsUser = await TDSUser.LoginWithTapTap();
                Log.Debug($"TapTapLogin success:{tdsUser} ");
                // 获取 TDSUser 属性
                var objectId = tdsUser.ObjectId; // 用户唯一标识
                var nickname = tdsUser["nickname"]; // 昵称
                var avatar = tdsUser["avatar"]; // 头像
                return objectId;
            }
            catch (Exception e)
            {
                Log.Debug("登录异常");
                Log.Debug(e.ToString());
                if (e is TapException tapError) // using TapTap.Common
                {
                    Log.Debug($"encounter exception:{tapError.code} message:{tapError.message}");
                    if (tapError.code == (int)TapErrorCode.ERROR_CODE_BIND_CANCEL) // 取消登录
                    {
                        Log.Debug("登录取消");
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static async ETTask GetUserInfo()
        {
            var profile = await TapLogin.FetchProfile();
            Log.Debug($"profile: {profile.ToJson()}");
            // name	     玩家在 TapTap 平台的昵称
            // avatar	 玩家在 TapTap 平台的头像 url
            // openid	 通过用户信息和游戏信息生成的用户唯一标识，每个玩家在每个游戏中的 openid 都是不一样的
            // unionid	 通过用户信息加上厂商信息生成的用户唯一标识，一个玩家在同一个厂商的所有游戏中 unionid 都是一样的，不同厂商下 unionid 不同
        }

        /// <summary>
        /// 登出当前账户
        /// </summary>
        public static async ETTask LoginOut()
        {
            // await TDSUser.Logout();
        }

        /// <summary>
        /// 时长统计
        /// </summary>
        /// <param name="turn"></param>
        public static void SetDurationStatisticsEnabled(bool turn)
        {
            // TapCommon.SetDurationStatisticsEnabled(turn);
        }
    }
}