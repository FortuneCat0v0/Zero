using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [FriendOf(typeof(RouterAddressComponent))]
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_ConnectAccountHandler : MessageHandler<Scene, Main2NetClient_ConnectAccount, NetClient2Main_ConnectAccount>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_ConnectAccount request, NetClient2Main_ConnectAccount response)
        {
            // 创建一个ETModel层的Session
            root.RemoveComponent<RouterAddressComponent>();
            // 获取路由跟realmDispatcher地址
            RouterAddressComponent routerAddressComponent = root.GetComponent<RouterAddressComponent>();
            if (routerAddressComponent == null)
            {
                routerAddressComponent =
                        root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                await routerAddressComponent.Init();
                root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily,
                    NetworkProtocol.UDP);
                root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;
            }

            NetComponent netComponent = root.GetComponent<NetComponent>();
            Session session =
                    await RouterHelper.CreateRouterSession(netComponent, NetworkHelper.ToIPEndPoint(routerAddressComponent.Info.Account),
                        request.Account, request.Password);

            root.AddComponent<SessionComponent>().Session = session;
        }
    }
}