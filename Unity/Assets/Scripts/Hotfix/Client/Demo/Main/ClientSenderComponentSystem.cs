namespace ET.Client
{
    [EntitySystemOf(typeof(ClientSenderComponent))]
    [FriendOf(typeof(ClientSenderComponent))]
    public static partial class ClientSenderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ClientSenderComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ClientSenderComponent self)
        {
            self.RemoveFiberAsync().Coroutine();
        }

        private static async ETTask RemoveFiberAsync(this ClientSenderComponent self)
        {
            if (self.fiberId == 0)
            {
                return;
            }

            int fiberId = self.fiberId;
            self.fiberId = 0;
            await FiberManager.Instance.Remove(fiberId);
        }

        public static async ETTask DisposeAsync(this ClientSenderComponent self)
        {
            await self.RemoveFiberAsync();
            self.Dispose();
        }

        public static async ETTask ConnectAccountAsync(this ClientSenderComponent self, string account, string password)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);

            Main2NetClient_ConnectAccount request = Main2NetClient_ConnectAccount.Create();
            request.OwnerFiberId = self.Fiber().Id;
            request.Account = account;
            request.Password = password;
            NetClient2Main_ConnectAccount response =
                    await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, request) as NetClient2Main_ConnectAccount;

            EventSystem.Instance.Publish(self.Root(), new ShowErrorTip() { Error = response.Error });
        }

        public static async ETTask<long> EnterGameAsync(this ClientSenderComponent self, long accountId, string realmKey, string realmAddress,
        long roleId, string account, string password)
        {
            Main2NetClient_EnterGame main2NetClientEnterGame = Main2NetClient_EnterGame.Create();
            main2NetClientEnterGame.OwnerFiberId = self.Fiber().Id;
            main2NetClientEnterGame.AccountId = accountId;
            main2NetClientEnterGame.RealmKey = realmKey;
            main2NetClientEnterGame.RealmAddress = realmAddress;
            main2NetClientEnterGame.RoleId = roleId;
            main2NetClientEnterGame.Account = account;
            main2NetClientEnterGame.Password = password;
            NetClient2Main_EnterGame response =
                    await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientEnterGame) as
                            NetClient2Main_EnterGame;

            EventSystem.Instance.Publish(self.Root(), new ShowErrorTip() { Error = response.Error });

            return response.MyId;
        }

        public static async ETTask<long> LoginAsync(this ClientSenderComponent self, string account, string password)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.NetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);

            Main2NetClient_Login main2NetClientLogin = Main2NetClient_Login.Create();
            main2NetClientLogin.OwnerFiberId = self.Fiber().Id;
            main2NetClientLogin.Account = account;
            main2NetClientLogin.Password = password;
            NetClient2Main_Login response =
                    await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, main2NetClientLogin) as NetClient2Main_Login;
            return response.PlayerId;
        }

        public static void Send(this ClientSenderComponent self, IMessage message)
        {
            A2NetClient_Message a2NetClientMessage = A2NetClient_Message.Create();
            a2NetClientMessage.MessageObject = message;
            self.Root().GetComponent<ProcessInnerSender>().Send(self.netClientActorId, a2NetClientMessage);
        }

        public static async ETTask<IResponse> Call(this ClientSenderComponent self, IRequest request, bool needException = true)
        {
            A2NetClient_Request a2NetClientRequest = A2NetClient_Request.Create();
            a2NetClientRequest.MessageObject = request;
            using A2NetClient_Response a2NetClientResponse =
                    await self.Root().GetComponent<ProcessInnerSender>().Call(self.netClientActorId, a2NetClientRequest) as A2NetClient_Response;
            IResponse response = a2NetClientResponse.MessageObject;

            if (response.Error == ErrorCore.ERR_MessageTimeout)
            {
                throw new RpcException(response.Error, $"Rpc error: request, 注意Actor消息超时，请注意查看是否死锁或者没有reply: {request}, response: {response}");
            }

            if (needException && ErrorCore.IsRpcNeedThrowException(response.Error))
            {
                throw new RpcException(response.Error, $"Rpc error: {request}, response: {response}");
            }

            EventSystem.Instance.Publish(self.Root(), new ShowErrorTip() { Error = response.Error });

            return response;
        }
    }
}