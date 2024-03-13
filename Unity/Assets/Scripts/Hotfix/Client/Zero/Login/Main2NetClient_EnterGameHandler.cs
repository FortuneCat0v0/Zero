using System.Net.Sockets;

namespace ET.Client
{
    [FriendOf(typeof(RouterAddressComponent))]
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_EnterGameHandler : MessageHandler<Scene, Main2NetClient_EnterGame, NetClient2Main_EnterGame>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_EnterGame request, NetClient2Main_EnterGame response)
        {
            // 断开与Account的连接
            root.GetComponent<SessionComponent>().Session.Dispose();
            NetComponent netComponent = root.GetComponent<NetComponent>();
            // 连接Realm，获取分配的Gate
            R2C_LoginRealm r2CLoginRealm;
            C2R_LoginRealm c2RLoginRealm = C2R_LoginRealm.Create();
            c2RLoginRealm.AccountId = request.AccountId;
            c2RLoginRealm.RealmTokenKey = request.RealmKey;
            using (Session session = await RouterHelper.CreateRouterSession(netComponent, NetworkHelper.ToIPEndPoint(request.RealmAddress),
                       request.Account, request.Password))
            {
                r2CLoginRealm = await session.Call(c2RLoginRealm) as R2C_LoginRealm;
            }

            if (r2CLoginRealm.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            // 开始连接Gate
            Session gateSession = await RouterHelper.CreateRouterSession(netComponent, NetworkHelper.ToIPEndPoint(r2CLoginRealm.GateAddress),
                request.Account, request.Password);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            root.GetComponent<SessionComponent>().Session = gateSession;

            C2G_LoginGameGate c2GLoginGameGate = C2G_LoginGameGate.Create();
            c2GLoginGameGate.Key = r2CLoginRealm.GateSessionKey;
            c2GLoginGameGate.AccountId = request.AccountId;
            c2GLoginGameGate.RoleId = request.RoleId;
            G2C_LoginGameGate g2CLoginGate = await gateSession.Call(c2GLoginGameGate) as G2C_LoginGameGate;

            if (g2CLoginGate.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            // 角色正式请求进入游戏逻辑服
            C2G_EnterGame c2GEnterGame = C2G_EnterGame.Create();
            G2C_EnterGame g2CEnterGame = await gateSession.Call(c2GEnterGame) as G2C_EnterGame;

            if (g2CEnterGame.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            response.MyId = g2CEnterGame.MyId;
        }
    }
}