using System;

namespace ET.Server
{
    [Invoke((long)SceneType.Gate)]
    public class NetComponentOnReadInvoker_Gate : AInvokeHandler<NetComponentOnRead>
    {
        public override void Handle(NetComponentOnRead args)
        {
            HandleAsync(args).Coroutine();
        }

        private async ETTask HandleAsync(NetComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;
            Scene root = args.Session.Root();
            // 根据消息接口判断是不是Actor消息，不同的接口做不同的处理,比如需要转发给Chat Scene，可以做一个IChatMessage接口
            switch (message)
            {
                case ISessionMessage:
                {
                    MessageSessionDispatcher.Instance.Handle(session, message);
                    break;
                }
                case FrameMessage frameMessage:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                    frameMessage.PlayerId = player.Id;
                    root.GetComponent<MessageSender>().Send(roomActorId, frameMessage);
                    break;
                }
                case IRoomMessage actorRoom:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                    actorRoom.PlayerId = player.Id;
                    root.GetComponent<MessageSender>().Send(roomActorId, actorRoom);
                    break;
                }
                case IChatRequest actorChatRequest:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    int rpcId = actorChatRequest.RpcId;
                    long instanceId = session.InstanceId;
                    IChatResponse iResponse =
                            await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Chat)
                                    .Call(player.Id, actorChatRequest) as IChatResponse;
                    iResponse.RpcId = rpcId;

                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }

                    break;
                }
                case IChatMessage actorChatMessage:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Chat).Send(player.Id, actorChatMessage);

                    break;
                }
                case IRankRequest actorRankRequest:
                {
                    ActorId rankActorId = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Rank").ActorId;
                    int rpcId = actorRankRequest.RpcId;
                    long instanceId = session.InstanceId;

                    IResponse iResponse = await root.GetComponent<MessageSender>().Call(rankActorId, actorRankRequest);
                    iResponse.RpcId = rpcId;

                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }

                    break;
                }
                case IRankMessage actorRankMessage:
                {
                    ActorId rankActorId = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Rank").ActorId;
                    root.GetComponent<MessageSender>().Send(rankActorId, actorRankMessage);

                    break;
                }
                case IMailRequest actorMailRequest:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    int rpcId = actorMailRequest.RpcId;
                    long instanceId = session.InstanceId;

                    IMailResponse iResponse =
                            await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Mail)
                                    .Call(player.Id, actorMailRequest) as IMailResponse;
                    iResponse.RpcId = rpcId;

                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }

                    break;
                }
                case IMailMessage actorMailMessage:
                {
                    Player player = session.GetComponent<SessionPlayerComponent>().Player;
                    root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Mail).Send(player.Id, actorMailMessage);

                    break;
                }
                case ILocationMessage actorLocationMessage:
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().Player.Id;
                    root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, actorLocationMessage);
                    break;
                }
                case ILocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().Player.Id;
                    int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit)
                            .Call(unitId, actorLocationRequest);
                    iResponse.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Send(iResponse);
                    }

                    break;
                }
                case IRequest actorRequest: // 分发IActorRequest消息，目前没有用到，需要的自己添加
                {
                    break;
                }
                case IMessage actorMessage: // 分发IActorMessage消息，目前没有用到，需要的自己添加
                {
                    break;
                }

                default:
                {
                    throw new Exception($"not found handler: {message}");
                }
            }
        }
    }
}