namespace ET.Server
{
    [ChildOf(typeof(RankComponent))]
    public class RankEntity : Entity, IAwake, IDestroy
    {
        public long UnitId;
        public string Name;
    }
}