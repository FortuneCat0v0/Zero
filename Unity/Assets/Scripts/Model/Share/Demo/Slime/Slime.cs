namespace ET
{
    public struct SlimeInfoChange
    {
        public SlimeInfo SlimeInfo;
    }

    public enum SlimeOpType
    {
        Add,
        Remove,
        Update,
    }

    [ChildOf]
    public class Slime : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public string Name;
        public int ConfigId;
        public int Age;
        public int LifeTime; //寿命
        public int Realm; //境界
    }
}