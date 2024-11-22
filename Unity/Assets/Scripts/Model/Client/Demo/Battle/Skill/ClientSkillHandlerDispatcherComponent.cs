using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Code]
    public class ClientSkillHandlerDispatcherComponent : Singleton<ClientSkillHandlerDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, ClientSkillHandler> skillCHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(ClientSkillHandlerAttribute));
            foreach (Type type in types)
            {
                ClientSkillHandler clientSkillHandler = Activator.CreateInstance(type) as ClientSkillHandler;
                if (clientSkillHandler == null)
                {
                    Log.Error($"not SkillHandler: {type.Name}");
                    continue;
                }

                this.skillCHandlers.Add(type.Name, clientSkillHandler);
            }
        }

        public ClientSkillHandler Get(string key)
        {
            this.skillCHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}