namespace ET
{
    public struct PetInfoChange
    {
        public PetInfo PetInfo;
    }

    public enum PetOpType
    {
        Add,
        Remove,
        Update,
    }

    [ChildOf]
    public class Pet : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public string Name;
        public int ConfigId;
        public int Age;
        public int LifeTime; //寿命
        public int Realm; //境界
    }
}