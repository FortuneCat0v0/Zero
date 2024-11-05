using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class SkillSHandlerDispatcherComponent : Singleton<SkillSHandlerDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillSHandler> skillSHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SkillSHandlerAttribute));
            foreach (Type type in types)
            {
                SkillSHandler skillHandler = Activator.CreateInstance(type) as SkillSHandler;
                if (skillHandler == null)
                {
                    Log.Error($"not SkillHandler: {type.Name}");
                    continue;
                }

                this.skillSHandlers.Add(type.Name, skillHandler);
            }
        }

        public SkillSHandler Get(string key)
        {
            this.skillSHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}