using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (Role))]
    [MessageSessionHandler(SceneType.Account)]
    public class C2A_GetRolesHandler: MessageSessionHandler<C2A_GetRoles, A2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2A_GetRoles request, A2C_GetRoles response)
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
                    List<Role> roleList = await root.GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Query<Role>(d =>
                            d.AccountId == request.AccountId && d.ServerId == request.ServerId && d.State == (int)RoleState.Normal);

                    if (roleList == null || roleList.Count == 0)
                    {
                        return;
                    }

                    foreach (Role role in roleList)
                    {
                        response.RoleInfos.Add(role.ToMessage());
                        role.Dispose();
                    }

                    roleList.Clear();
                }
            }
        }
    }
}