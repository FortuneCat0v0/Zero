using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class CollisionHandlerDispatcherComponent : Singleton<CollisionHandlerDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, CollisionHandler> collisionHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(CollisionHandlerAttribute));
            foreach (Type type in types)
            {
                CollisionHandler collisionHandler = Activator.CreateInstance(type) as CollisionHandler;
                if (collisionHandler == null)
                {
                    Log.Error($"is not CollisionHandler: {type.Name}");
                    continue;
                }

                this.collisionHandlers.Add(type.Name, collisionHandler);
            }
        }

        public void HandleCollisionStart(Unit a, Unit b)
        {
            string collisionHandlerName = a.GetComponent<ColliderComponent>().CollisionHandler;

            if (string.IsNullOrEmpty(collisionHandlerName))
            {
                return;
            }

            this.collisionHandlers.TryGetValue(collisionHandlerName, out CollisionHandler collisionHandler);
            if (collisionHandler == null)
            {
                return;
            }

            collisionHandler.HandleCollisionStart(a, b);
        }

        public void HandleCollisionSustain(Unit a, Unit b)
        {
            string collisionHandlerName = a.GetComponent<ColliderComponent>().CollisionHandler;

            if (string.IsNullOrEmpty(collisionHandlerName))
            {
                return;
            }

            this.collisionHandlers.TryGetValue(collisionHandlerName, out CollisionHandler collisionHandler);
            if (collisionHandler == null)
            {
                Log.Error($"not found collisionHandler: {collisionHandlerName}");
                return;
            }

            collisionHandler.HandleCollisionSustain(a, b);
        }

        public void HandleCollisionEnd(Unit a, Unit b)
        {
            string collisionHandlerName = a.GetComponent<ColliderComponent>().CollisionHandler;

            if (string.IsNullOrEmpty(collisionHandlerName))
            {
                return;
            }

            this.collisionHandlers.TryGetValue(collisionHandlerName, out CollisionHandler collisionHandler);
            if (collisionHandler == null)
            {
                Log.Error($"not found collisionHandler: {collisionHandlerName}");
                return;
            }

            collisionHandler.HandleCollisionEnd(a, b);
        }
    }
}