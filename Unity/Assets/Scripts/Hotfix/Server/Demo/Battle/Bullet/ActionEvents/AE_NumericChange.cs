using System.Collections.Generic;

namespace ET.Server
{
    public class AE_NumericChange : AActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发改变数值事件");
            Buff buff = entity as Buff;
            Scene root = buff.Root();
            Unit owner = buff.OwnerUnit;

            NumericComponent numericComponent = owner.GetComponent<NumericComponent>();
            long oldValue = numericComponent.GetAsLong(param[0]);
            long newValue = oldValue + param[1];
            numericComponent.Set(param[0], newValue);

            await ETTask.CompletedTask;
        }
    }
}