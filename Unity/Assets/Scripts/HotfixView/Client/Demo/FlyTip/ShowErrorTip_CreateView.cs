using System;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShowErrorTip_CreateView : AEvent<Scene, ShowErrorTip>
    {
        protected override async ETTask Run(Scene scene, ShowErrorTip args)
        {
            string str = args.Error switch
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
                _ => string.Empty
            };

            if (!string.IsNullOrEmpty(str))
            {
                FlyTipComponent.Instance.ShowFlyTip(str);
            }

            await ETTask.CompletedTask;
        }
    }
}