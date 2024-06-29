﻿using System.Collections.Generic;

namespace ET
{
    public class ActionEventAttribute : BaseAttribute
    {
    }

    [ActionEvent]
    public abstract class AActionEvent : HandlerObject
    {
        public abstract ETTask Execute(Skill skill, List<int> param, ETCancellationToken cancellationToken);
    }
}