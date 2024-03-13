namespace ET.Server
{
    /// <summary>
    /// 60秒后自动断开Session
    /// </summary>
    [ComponentOf(typeof (Session))]
    public class AccountCheckOutTimeComponent: Entity, IAwake<long>, IDestroy
    {
        public long Timer = 0;

        public long AccountId = 0;
    }
}