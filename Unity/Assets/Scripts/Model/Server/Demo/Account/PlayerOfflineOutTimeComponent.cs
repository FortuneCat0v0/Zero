namespace ET.Server
{
    /// <summary>
    /// 10秒后进行KickPlayer
    /// </summary>
    [ComponentOf(typeof (Player))]
    public class PlayerOfflineOutTimeComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
    }
}