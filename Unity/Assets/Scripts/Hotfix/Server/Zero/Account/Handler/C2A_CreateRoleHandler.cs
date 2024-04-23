using System;

namespace ET.Server
{
    [FriendOf(typeof(Role))]
    [MessageSessionHandler(SceneType.Account)]
    public class C2A_CreateRoleHandler : MessageSessionHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response)
        {
            Scene root = session.Root();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            string token = root.GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roleList = await root.GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                            .Query<Role>(d => d.Name == request.Name && d.ServerId == request.ServerId && d.State != (int)RoleState.Freeze);

                    if (roleList != null && roleList.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        return;
                    }

                    Role newRole = session.AddChild<Role>();
                    newRole.Name = request.Name;
                    newRole.State = (int)RoleState.Normal;
                    newRole.ServerId = request.ServerId;
                    newRole.AccountId = request.AccountId;
                    newRole.CreateTime = TimeInfo.Instance.ServerNow();
                    newRole.LastLoginTime = 0;

                    await root.GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(newRole);

                    response.RoleInfo = newRole.ToMessage();
                }
            }
        }
    }
}