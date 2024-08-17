using System.Collections.Generic;
using System.Net;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class RouterComponent: Entity, IAwake<IPEndPoint, string>, IDestroy, IUpdate
    {
        public IKcpTransport OuterUdp;
        public IKcpTransport OuterTcp;
        public IKcpTransport InnerSocket;
        public EndPoint IPEndPoint = new IPEndPoint(IPAddress.Any, 0);

        public byte[] Cache = new byte[1500];

        public Queue<uint> checkTimeout = new();

        public long LastCheckTime = 0;
    }
}