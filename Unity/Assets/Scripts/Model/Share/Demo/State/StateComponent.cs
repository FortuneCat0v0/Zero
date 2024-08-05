namespace ET
{
    public class StateComponent : Entity, IAwake, ITransfer, IDeserialize
    {
        public StateType CurrentStateType;
    }

    [FriendOf(typeof(StateComponent))]
    [EntitySystemOf(typeof(StateComponent))]
    public static partial class StateComponentSystem
    {
        [EntitySystem]
        private static void Awake(this StateComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this StateComponent self)
        {
        }

        public static bool CheckConflictState(this StateComponent self, StateType stateType)
        {
            StateType conflictStateType = self.GetConflictState(stateType);

            if ((conflictStateType & self.CurrentStateType) == 0)
            {
                return false;
            }

            return true;
        }

        public static StateType GetConflictState(this StateComponent self, StateType stateType)
        {
            StateType conflictStateType = 0;
            switch (stateType)
            {
                case StateType.None:
                    conflictStateType = 0;
                    break;
                case StateType.Run:
                    conflictStateType = StateType.RePluse | StateType.Dizziness | StateType.Striketofly | StateType.Sneer | StateType.Fear;
                    break;
                // ....
            }

            return conflictStateType;
        }

        public static bool ExistState(this StateComponent self, StateType stateType)
        {
            StateType state = self.CurrentStateType & stateType;

            if (state > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddState(this StateComponent self, StateType stateType)
        {
            StateType conflictStateType = self.GetConflictState(stateType);
            self.RemoveState(conflictStateType);

            self.CurrentStateType = self.CurrentStateType | stateType;
            Log.Debug($"添加{stateType}状态");

            Unit unit = self.GetParent<Unit>();

            // EventSystem.Instance.Publish(self.Scene(), new StateTypeAdd() { UnitDefend = unit, nowStateType = stateType });
        }

        public static void RemoveState(this StateComponent self, StateType stateType)
        {
            self.CurrentStateType = self.CurrentStateType & ~stateType;
            Log.Debug($"移除{stateType}状态");

            Unit unit = self.GetParent<Unit>();

            // EventSystem.Instance.Publish(self.Scene(), new StateTypeRemove() { UnitDefend = unit, nowStateType = stateType });
        }
    }
}