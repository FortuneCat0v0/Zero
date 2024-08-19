namespace ET
{
    [ComponentOf]
    public class TimeoutComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer;
    }
}