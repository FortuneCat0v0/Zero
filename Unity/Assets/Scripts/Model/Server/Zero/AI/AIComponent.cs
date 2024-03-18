namespace ET.Server
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf]
    public class AIComponent: Entity, IAwake<int>, IDestroy
    {
        public int AIConfigId;
        
        public ETCancellationToken CancellationToken;

        public long Timer;

        public int Current;
    }
}