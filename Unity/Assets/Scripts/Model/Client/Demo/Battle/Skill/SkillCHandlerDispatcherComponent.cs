using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Code]
    public class SkillCHandlerDispatcherComponent : Singleton<SkillCHandlerDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillCHandler> skillCHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SkillCHandlerAttribute));
            foreach (Type type in types)
            {
                SkillCHandler skillHandler = Activator.CreateInstance(type) as SkillCHandler;
                if (skillHandler == null)
                {
                    Log.Error($"not SkillHandler: {type.Name}");
                    continue;
                }

                this.skillCHandlers.Add(type.Name, skillHandler);
            }
        }

        public SkillCHandler Get(string key)
        {
            this.skillCHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}