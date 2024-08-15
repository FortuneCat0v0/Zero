namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class ColliderTimeoutComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer;
    }
}