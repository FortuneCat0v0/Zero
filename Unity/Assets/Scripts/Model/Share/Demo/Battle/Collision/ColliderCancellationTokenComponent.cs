namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class ColliderCancellationTokenComponent : Entity, IAwake<ETCancellationToken>, IDestroy
    {
        public long Timer;
        public ETCancellationToken CancellationToken { get; set; }
    }
}