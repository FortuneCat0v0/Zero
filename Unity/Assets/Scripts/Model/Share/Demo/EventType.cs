using System;

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

    public struct UnitDeath
    {
        public Unit AttackUnit;
        public Unit DefendUnit;
    }

    public struct HitResult
    {
        public Unit FromUnit;
        public Unit ToUnit;
        public EHitResultType HitResultType;
        public int Value;
    }

    public struct ChangeEquipItem
    {
        public Unit Unit;
        public Item Item;
        public EquipPosition EquipPosition;
        public EquipOp EquipOp;
    }

    public struct UnitGetComponent
    {
        public EntityRef<Unit> Unit;
        public Type Type;
    }
}