using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class SkillHandlerDispatcherComponent : Singleton<SkillHandlerDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, SkillHandler> skillSHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SkillHandlerAttribute));
            foreach (Type type in types)
            {
                SkillHandler skillHandler = Activator.CreateInstance(type) as SkillHandler;
                if (skillHandler == null)
                {
                    Log.Error($"not SkillHandler: {type.Name}");
                    continue;
                }

                this.skillSHandlers.Add(type.Name, skillHandler);
            }
        }

        public SkillHandler Get(string key)
        {
            this.skillSHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}