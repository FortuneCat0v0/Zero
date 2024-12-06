namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_NetWorkError = 200002;
        public const int ERR_LoginInfoIsNull = 200003;
        public const int ERR_AccountNameFormError = 200004;
        public const int ERR_PasswordFormError = 200005;
        public const int ERR_AccountInBlackListError = 200006;
        public const int ERR_LoginPasswordError = 200007;
        public const int ERR_RequestRepeatedly = 200008;
        public const int ERR_TokenError = 200009;
        public const int ERR_RoleNameIsNull = 200010;
        public const int ERR_RoleNameSame = 200011;
        public const int ERR_RoleNotExist = 200012;
        public const int ERR_ConnectGateKeyError = 200013;
        public const int ERR_RequestSceneTypeError = 200014;
        public const int ERR_OtherAccountLogin = 200016;
        public const int ERR_SessionPlayerError = 200017;
        public const int ERR_NonePlayerError = 200018;
        public const int ERR_PlayerSessionError = 200019;
        public const int ERR_ReEnterGameError = 200020;
        public const int ERR_ReEnterGameError2 = 200021;
        public const int ERR_EnterGameError = 200022;
        public const int ERR_SessionStateError = 200023;
        public const int ERR_ResourceUpdateVersionError = 200024;
        public const int ERR_ResourceUpdateManifestError = 200025;
        public const int ERR_ResourceUpdateDownloadError = 200026;
        public const int ERR_ItemNotExist = 200027;
        public const int ERR_BagMaxLoad = 200028;
        public const int ERR_EquipItemError = 200029;
        public const int ERR_AddBagItemError = 200030;
        public const int ERR_AddMapItemError = 200031;
        public const int ERR_RechargeError = 200032;
        public const int ERR_ChatMessageEmpty = 200033;
        public const int ERR_AppVersionError = 200034;

        public static string GetTip(int errorCode)
        {
            return errorCode switch
            {
                ErrorCode.ERR_Success => string.Empty,
                ErrorCode.ERR_NetWorkError => "网络错误",
                ErrorCode.ERR_LoginInfoIsNull => "登录信息错误",
                ErrorCode.ERR_AccountNameFormError => "登录账号格式错误",
                ErrorCode.ERR_PasswordFormError => "登录密码格式错误",
                ErrorCode.ERR_AccountInBlackListError => "账号处于黑名单中",
                ErrorCode.ERR_LoginPasswordError => "登录密码错误",
                ErrorCode.ERR_RequestRepeatedly => "反复多次请求",
                ErrorCode.ERR_TokenError => "令牌Token错误",
                ErrorCode.ERR_RoleNameIsNull => "游戏角色名称为空",
                ErrorCode.ERR_RoleNameSame => "游戏角色名同名",
                ErrorCode.ERR_RoleNotExist => "游戏角色不存在",
                ErrorCode.ERR_ConnectGateKeyError => "连接Gate的令牌错误",
                ErrorCode.ERR_RequestSceneTypeError => "请求的Scene错误",
                ErrorCode.ERR_OtherAccountLogin => "顶号登录",
                ErrorCode.ERR_SessionPlayerError => string.Empty,
                ErrorCode.ERR_NonePlayerError => string.Empty,
                ErrorCode.ERR_PlayerSessionError => string.Empty,
                ErrorCode.ERR_ReEnterGameError => string.Empty,
                ErrorCode.ERR_ReEnterGameError2 => string.Empty,
                ErrorCode.ERR_EnterGameError => string.Empty,
                ErrorCode.ERR_SessionStateError => string.Empty,
                ErrorCode.ERR_ResourceUpdateVersionError => string.Empty,
                ErrorCode.ERR_ResourceUpdateManifestError => string.Empty,
                ErrorCode.ERR_ResourceUpdateDownloadError => string.Empty,
                ErrorCode.ERR_ItemNotExist => string.Empty,
                ErrorCode.ERR_BagMaxLoad => string.Empty,
                ErrorCode.ERR_EquipItemError => string.Empty,
                ErrorCode.ERR_AddBagItemError => string.Empty,
                ErrorCode.ERR_AddMapItemError => string.Empty,
                ErrorCode.ERR_RechargeError => "充值金额错误",
                ErrorCode.ERR_ChatMessageEmpty => string.Empty,
                ErrorCode.ERR_AppVersionError => "游戏版本错误",
                _ => string.Empty
            };
        }
    }
}