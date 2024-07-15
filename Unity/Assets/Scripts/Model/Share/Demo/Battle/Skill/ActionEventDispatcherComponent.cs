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

        public void HandleExecute(Entity entity, string actionEventName, List<int> param, ETCancellationToken cancellationToken = null)
        {
            this.actionEvents.TryGetValue(actionEventName, out AActionEvent actionEvent);
            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            actionEvent.Execute(entity, param, cancellationToken).Coroutine();
        }

        public void HandleCollisionStart(Unit a, Unit b)
        {
            string actionEventName = a.GetComponent<ColliderComponent>().ActionEvent;

            if (string.IsNullOrEmpty(actionEventName))
            {
                return;
            }

            this.actionEvents.TryGetValue(actionEventName, out AActionEvent actionEvent);
            if (actionEvent == null)
            {
                return;
            }

            actionEvent.HandleCollisionStart(a, b);
        }

        public void HandleCollisionSustain(Unit a, Unit b)
        {
            string actionEventName = a.GetComponent<ColliderComponent>().ActionEvent;

            if (string.IsNullOrEmpty(actionEventName))
            {
                return;
            }

            this.actionEvents.TryGetValue(actionEventName, out AActionEvent actionEvent);
            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            actionEvent.HandleCollisionSustain(a, b);
        }

        public void HandleCollisionEnd(Unit a, Unit b)
        {
            string actionEventName = a.GetComponent<ColliderComponent>().ActionEvent;

            if (string.IsNullOrEmpty(actionEventName))
            {
                Log.Debug($"unitA {a.Id} Contact unitB {b.Id} but UnitA ActionEvent is null");
                return;
            }

            this.actionEvents.TryGetValue(actionEventName, out AActionEvent actionEvent);
            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            actionEvent.HandleCollisionStart(a, b);
        }
    }
}