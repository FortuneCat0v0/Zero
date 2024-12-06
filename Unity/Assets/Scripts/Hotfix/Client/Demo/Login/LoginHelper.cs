namespace ET.Client
{
    [FriendOf(typeof(RoleComponent))]
    [FriendOf(typeof(GameServerComponent))]
    public static partial class LoginHelper
    {
        public static async ETTask<int> LoginAccount(Scene root, string account, string password, ELoginType loginType)
        {
            ClientSenderComponent clientSenderComponent = root.GetComponent<ClientSenderComponent>();
            if (clientSenderComponent != null)
            {
                await clientSenderComponent.DisposeAsync();
            }

            clientSenderComponent = root.AddComponent<ClientSenderComponent>();
            await clientSenderComponent.ConnectAccountAsync();

            C2A_LoginAccount request = C2A_LoginAccount.Create();
            request.AppVersion = GlobalValue.AppVersion;
            request.Account = account;
            request.Password = password;
            request.ELoginType = (int)loginType;
            A2C_LoginAccount response = await clientSenderComponent.Call(request) as A2C_LoginAccount;
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            root.GetComponent<AccountComponent>().Token = response.Token;
            root.GetComponent<AccountComponent>().AccountId = response.AccountId;

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetServerInfos(Scene root)
        {
            C2A_GetServers c2AGetServers = C2A_GetServers.Create();
            c2AGetServers.AccountId = root.GetComponent<AccountComponent>().AccountId;
            c2AGetServers.Token = root.GetComponent<AccountComponent>().Token;
            A2C_GetServers a2CGetServers = await root.GetComponent<ClientSenderComponent>().Call(c2AGetServers) as A2C_GetServers;

            if (a2CGetServers.Error != ErrorCode.ERR_Success)
            {
                return a2CGetServers.Error;
            }

            foreach (ServerInfo serverInfo in a2CGetServers.ServerInfos)
            {
                GameServer server = root.GetComponent<GameServerComponent>().AddChildWithId<GameServer>(serverInfo.Id);
                server.FromMessage(serverInfo);
                root.GetComponent<GameServerComponent>().GameServers.Add(server);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoles(Scene root)
        {
            C2A_GetRoles c2AGetRoles = C2A_GetRoles.Create();
            c2AGetRoles.AccountId = root.GetComponent<AccountComponent>().AccountId;
            c2AGetRoles.Token = root.GetComponent<AccountComponent>().Token;
            c2AGetRoles.ServerId = root.GetComponent<GameServerComponent>().CurrentServerId;
            A2C_GetRoles a2CGetRoles = await root.GetComponent<ClientSenderComponent>().Call(c2AGetRoles) as A2C_GetRoles;
            if (a2CGetRoles.Error != ErrorCode.ERR_Success)
            {
                return a2CGetRoles.Error;
            }

            foreach (RoleInfo roleInfo in a2CGetRoles.RoleInfos)
            {
                Role role = root.GetComponent<RoleComponent>().AddChildWithId<Role>(roleInfo.Id);
                role.FromMessage(roleInfo);
                root.GetComponent<RoleComponent>().Roles.Add(role);
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene root, string name)
        {
            C2A_CreateRole c2ACreateRole = C2A_CreateRole.Create();
            c2ACreateRole.AccountId = root.GetComponent<AccountComponent>().AccountId;
            c2ACreateRole.Token = root.GetComponent<AccountComponent>().Token;
            c2ACreateRole.Name = name;
            c2ACreateRole.ServerId = root.GetComponent<GameServerComponent>().CurrentServerId;
            A2C_CreateRole a2CCreateRole = await root.GetComponent<ClientSenderComponent>().Call(c2ACreateRole) as A2C_CreateRole;

            if (a2CCreateRole.Error != ErrorCode.ERR_Success)
            {
                return a2CCreateRole.Error;
            }

            Role newRole = root.GetComponent<RoleComponent>().AddChildWithId<Role>(a2CCreateRole.RoleInfo.Id);
            newRole.FromMessage(a2CCreateRole.RoleInfo);
            root.GetComponent<RoleComponent>().Roles.Add(newRole);

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRole(Scene root)
        {
            C2A_DeleteRole c2ADeleteRole = C2A_DeleteRole.Create();
            c2ADeleteRole.Token = root.GetComponent<AccountComponent>().Token;
            c2ADeleteRole.AccountId = root.GetComponent<AccountComponent>().AccountId;
            c2ADeleteRole.RoleId = root.GetComponent<RoleComponent>().CurrentRoleId;
            c2ADeleteRole.ServerId = root.GetComponent<GameServerComponent>().CurrentServerId;
            A2C_DeleteRole a2CDeleteRole = await root.GetComponent<ClientSenderComponent>().Call(c2ADeleteRole) as A2C_DeleteRole;

            if (a2CDeleteRole.Error != ErrorCode.ERR_Success)
            {
                return a2CDeleteRole.Error;
            }

            root.GetComponent<RoleComponent>().Remove(a2CDeleteRole.DeletedRoleId);

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRealmKey(Scene root)
        {
            C2A_GetRealmKey c2AGetRealmKey = C2A_GetRealmKey.Create();
            c2AGetRealmKey.Token = root.GetComponent<AccountComponent>().Token;
            c2AGetRealmKey.AccountId = root.GetComponent<AccountComponent>().AccountId;
            c2AGetRealmKey.ServerId = root.GetComponent<GameServerComponent>().CurrentServerId;
            A2C_GetRealmKey a2CGetRealmKey = await root.GetComponent<ClientSenderComponent>().Call(c2AGetRealmKey) as A2C_GetRealmKey;

            if (a2CGetRealmKey.Error != ErrorCode.ERR_Success)
            {
                return a2CGetRealmKey.Error;
            }

            root.GetComponent<AccountComponent>().RealmKey = a2CGetRealmKey.RealmKey;
            root.GetComponent<AccountComponent>().RealmAddress = a2CGetRealmKey.RealmAddress;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterGame(Scene root)
        {
            AccountComponent accountComponent = root.GetComponent<AccountComponent>();
            ClientSenderComponent clientSenderComponent = root.GetComponent<ClientSenderComponent>();

            long myId = await clientSenderComponent.EnterGameAsync(accountComponent.AccountId, accountComponent.RealmKey,
                accountComponent.RealmAddress, root.GetComponent<RoleComponent>().CurrentRoleId);

            root.GetComponent<PlayerComponent>().MyId = myId;

            Log.Debug("角色进入游戏成功!!!!");

            return ErrorCode.ERR_Success;
        }
    }
}