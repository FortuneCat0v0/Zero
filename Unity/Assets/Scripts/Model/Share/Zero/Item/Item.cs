namespace ET
{
    [ChildOf]
    public class Item : Entity, IAwake, IAwake<int>, ISerializeToEntity
    {
        public int ItemConfigId { get; set; }
    }
}