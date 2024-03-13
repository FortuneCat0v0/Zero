using System;

namespace ET.Server
{
    [FriendOf(typeof (Role))]
    [MessageSessionHandler(SceneType.Account)]
    public class C2A_DeleteRoleHandler: MessageSessionHandler<C2A_DeleteRole, A2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response)
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

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await root.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roleList = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(request.ServerId)
                            .Query<Role>(d => d.Id == request.RoleId && d.ServerId == request.ServerId);

                    if (roleList == null || roleList.Count <= 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNotExist;
                        return;
                    }

                    Role role = roleList[0];
                    session.GetComponent<RolesZone>().AddChild(role);

                    role.State = (int)RoleState.Freeze;

                    await root.GetComponent<DBManagerComponent>().GetZoneDB(request.ServerId).Save(role);
                    response.DeletedRoleId = role.Id;
                    role.Dispose();
                }
            }
        }
    }
}