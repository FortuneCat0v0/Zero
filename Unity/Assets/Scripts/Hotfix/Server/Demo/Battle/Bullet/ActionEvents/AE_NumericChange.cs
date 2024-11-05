using System.Collections.Generic;

namespace ET.Server
{
    public class AE_NumericChange : ActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Log.Info("触发改变数值事件");
            BuffS buffS = entity as BuffS;
            Scene root = buffS.Root();
            Unit owner = buffS.OwnerUnit;

            NumericComponent numericComponent = owner.GetComponent<NumericComponent>();
            long oldValue = numericComponent.GetAsLong(param[0]);
            long newValue = oldValue + param[1];
            numericComponent.Set(param[0], newValue);

            await ETTask.CompletedTask;
        }
    }
}