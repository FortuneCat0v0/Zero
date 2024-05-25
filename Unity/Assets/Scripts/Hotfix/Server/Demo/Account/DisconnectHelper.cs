namespace ET.Server
{
    public static class DisconnectHelper
    {
        public static async ETTask Disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;

            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);

            if (self.InstanceId != instanceId)
            {
                return;
            }

            self.Dispose();
        }

        public static async ETTask KickPlayer(Player player, bool isException = false)
        {
            if (player == null || player.IsDisposed)
            {
                return;
            }

            long instanceId = player.InstanceId;
            using (await player.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginGate, player.AccountId.GetHashCode()))
            {
                if (player.IsDisposed || instanceId != player.InstanceId)
                {
                    return;
                }

                if (!isException)
                {
                    switch (player.PlayerState)
                    {
                        case PlayerState.Disconnect:
                            break;
                        case PlayerState.Gate:
                            break;
                        case PlayerState.Game:
                            // 通知游戏逻辑服下线Unit角色逻辑，并将数据存入数据库
                            player.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit)
                                    .Send(player.Id, G2M_RequestExitGame.Create());

                            //通知聊天服下线聊天Unit
                            // var chat2GRequestExitChat = (Chat2G_RequestExitChat)await MessageHelper.CallActor(player.ChatInfoInstanceId,new G2Chat_RequestExitChat());

                            //通知移除账号角色登录信息
                            StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenter;
                            G2L_RemoveLoginRecord g2LRemoveLoginRecord = G2L_RemoveLoginRecord.Create();
                            g2LRemoveLoginRecord.AccountId = player.AccountId;
                            g2LRemoveLoginRecord.ServerId = player.Zone();
                            L2G_RemoveLoginRecord l2GRemoveLoginRecord =
                                    await player.Root().GetComponent<MessageSender>().Call(loginCenterConfig.ActorId, g2LRemoveLoginRecord) as
                                            L2G_RemoveLoginRecord;
                            break;
                    }
                }

                player.Root().GetComponent<PlayerComponent>().Remove(player);
            }
        }
    }
}