namespace ET
{
    [ChildOf(typeof(SlimeComponent))]
    public class Slime : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public string Name;
    }
}