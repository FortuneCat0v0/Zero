using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class ActionEventDispatcherComponent : Singleton<ActionEventDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, AActionEvent> actionEvents = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(ActionEventAttribute));
            foreach (Type type in types)
            {
                AActionEvent actionEvent = Activator.CreateInstance(type) as AActionEvent;
                if (actionEvent == null)
                {
                    Log.Error($"is not ActionEvent: {type.Name}");
                    continue;
                }

                this.actionEvents.Add(type.Name, actionEvent);
            }
        }

        public AActionEvent Get(string key)
        {
            this.actionEvents.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }

        public void Trigger(Entity entity, string actionEventName, List<int> param, ETCancellationToken cancellationToken = null)
        {
            AActionEvent actionEvent = ActionEventDispatcherComponent.Instance.Get(actionEventName);

            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            actionEvent.Execute(entity, param, cancellationToken).Coroutine();
        }
    }
}