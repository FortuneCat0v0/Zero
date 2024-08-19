namespace ET
{
    [ComponentOf]
    public class CancellationComponent : Entity, IAwake<ETCancellationToken>, IDestroy
    {
        public long Timer;
        public ETCancellationToken CancellationToken { get; set; }
    }
}