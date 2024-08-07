using System.Collections.Generic;

namespace ET
{
    public class ActionEventAttribute : BaseAttribute
    {
    }

    [ActionEvent]
    public abstract class ActionEvent : HandlerObject
    {
        public abstract ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken = null);
    }
}