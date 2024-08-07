using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class ActionEventDispatcherComponent : Singleton<ActionEventDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, ActionEvent> actionEvents = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(ActionEventAttribute));
            foreach (Type type in types)
            {
                ActionEvent actionEvent = Activator.CreateInstance(type) as ActionEvent;
                if (actionEvent == null)
                {
                    Log.Error($"is not ActionEvent: {type.Name}");
                    continue;
                }

                this.actionEvents.Add(type.Name, actionEvent);
            }
        }

        public void HandleExecute(Entity entity, string actionEventName, List<int> param, ETCancellationToken cancellationToken = null)
        {
            this.actionEvents.TryGetValue(actionEventName, out ActionEvent actionEvent);
            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            actionEvent.Execute(entity, param, cancellationToken).Coroutine();
        }
    }
}