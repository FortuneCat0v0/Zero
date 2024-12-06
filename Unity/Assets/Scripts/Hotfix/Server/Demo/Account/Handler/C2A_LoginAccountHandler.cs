using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET.Server
{
    [FriendOf(typeof(Account))]
    [MessageSessionHandler(SceneType.Account)]
    public partial class C2A_LoginAccountHandler : MessageSessionHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response)
        {
            Scene root = session.Root();
            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            if (request.AppVersion != GlobalValue.AppVersion)
            {
                response.Error = ErrorCode.ERR_AppVersionError;
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_LoginInfoIsNull;
                session.Disconnect().Coroutine();
                return;
            }

            if (request.ELoginType == (int)ELoginType.Normal)
            {
                if (!Regex.IsMatch(request.Account.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
                {
                    response.Error = ErrorCode.ERR_AccountNameFormError;
                    session.Disconnect().Coroutine();
                    return;
                }

                if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$"))
                {
                    response.Error = ErrorCode.ERR_PasswordFormError;
                    session.Disconnect().Coroutine();
                    return;
                }
            }

            //防止同一用户短时间频繁登录
            using (session.AddComponent<SessionLockingComponent>())
            {
                //防止不同用户同时用相同的账号密码登录
                using (await root.GetComponent<CoroutineLockComponent>()
                               .Wait(CoroutineLockType.LoginAccount, request.Account.Trim().GetHashCode()))
                {
                    List<Account> accounts = await root.GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                            .Query<Account>(d => d.AccountName.Equals(request.Account.Trim()));
                    Account account = null;
                    if (accounts != null && accounts.Count > 0)
                    {
                        account = accounts[0];
                        session.AddChild(account);
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            session.Disconnect().Coroutine();
                            return;
                        }

                        if (!account.Password.Equals(request.Password))
                        {
                            response.Error = ErrorCode.ERR_LoginPasswordError;
                            session.Disconnect().Coroutine();
                            return;
                        }
                    }
                    else
                    {
                        // 不存在账号则立刻新创建一个
                        account = session.AddChild<Account>();
                        account.AccountName = request.Account.Trim();
                        account.Password = request.Password;
                        account.CreateTime = TimeInfo.Instance.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        account.LoginType = request.ELoginType;
                        await root.GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(account);
                    }

                    // 通知账号中心服,记录玩家登录，若已经在线则踢下线之前的玩家
                    StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "LoginCenter");
                    A2L_LoginAccountRequest a2LLoginAccountRequest = A2L_LoginAccountRequest.Create();
                    a2LLoginAccountRequest.AccountId = account.Id;
                    L2A_LoginAccountResponse l2ALoginAccountResponse =
                            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, a2LLoginAccountRequest) as
                                    L2A_LoginAccountResponse;

                    if (l2ALoginAccountResponse.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = l2ALoginAccountResponse.Error;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    // 断开同一个玩家与Account的连接
                    long otherSessionId = root.GetComponent<AccountSessionComponent>().Get(account.Id);
                    Session otherSession = root.GetComponent<NetComponent>().GetChild<Session>(otherSessionId);
                    if (otherSession != null)
                    {
                        A2C_Disconnect a2CDisconnect = A2C_Disconnect.Create();
                        a2CDisconnect.Error = 0;
                        otherSession.Send(a2CDisconnect);
                        otherSession.Disconnect().Coroutine();
                    }

                    root.GetComponent<AccountSessionComponent>().Add(account.Id, session.Id);
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);

                    string token = TimeInfo.Instance.ServerNow() + RandomGenerator.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    root.GetComponent<TokenComponent>().Remove(account.Id);
                    root.GetComponent<TokenComponent>().Add(account.Id, token);

                    response.AccountId = account.Id;
                    response.Token = token;
                }
            }
        }
    }
}