using System;
using System.Collections.Generic;

namespace MekaruStudios.MonsterCreator
{
    public class ServiceLocator
    {
        static ServiceLocator _instance;
        public static ServiceLocator Instance
        {
            get
            {
                _instance ??= new ServiceLocator();
                return _instance;
            }
            
        }
        
        readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
        
        public void Provide<TService>(TService implementation)
        {
            _services[typeof(TService)] = implementation;
        }

        public TService Resolve<TService>()
        {
            if (_services.TryGetValue(typeof(TService), out var value))
                return (TService)value;
            
            throw new ServiceResolutionException($"Service of type {typeof(TService)} not found.");
        }

        public static void LoadDependencies() => DependencyLoader.LoadDependencies();
        public static void DestroyInstance() => _instance = null;
    }
}
