namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MapComponent : Entity, IAwake, IDestroy
    {
        public MapType MapType { get; set; }
        public int MapConfigId { get; set; }
    }
}