using Box2DSharp.Dynamics.Contacts;

namespace ET
{
    public struct SceneChangeStart
    {
    }

    public struct SceneChangeFinish
    {
    }

    public struct AfterCreateClientScene
    {
    }

    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct OnCollisionContact
    {
        public Contact contact;
        public bool isEnd;
    }

    public struct ChangeEquipItem
    {
        public Unit Unit;
        public Item Item;
        public EquipPosition EquipPosition;
        public EquipOp EquipOp;
    }
}