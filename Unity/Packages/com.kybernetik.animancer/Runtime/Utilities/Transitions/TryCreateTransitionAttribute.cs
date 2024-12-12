// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2024 Kybernetik //

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Animancer
{
    /// <summary>Attribute for static methods which try to create a transition from an object.</summary>
    /// <remarks>
    /// The method signature must be:
    /// <c>static ITransitionDetailed TryCreateTransition(Object target)</c>
    /// </remarks>
    /// https://kybernetik.com.au/animancer/api/Animancer/TryCreateTransitionAttribute
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TryCreateTransitionAttribute : Attribute
    {
        /************************************************************************************************************************/
#if UNITY_EDITOR
        /************************************************************************************************************************/

        private static List<Func<Object, ITransitionDetailed>> _Methods;

        /// <summary>[Editor-Only] Ensures that all methods with this attribute have been gathered.</summary>
        private static void InitializeMethods()
        {
            if (_Methods != null)
                return;

            _Methods = new();

            foreach (var method in TypeCache.GetMethodsWithAttribute<TryCreateTransitionAttribute>())
            {
                try
                {
                    var func = Delegate.CreateDelegate(typeof(Func<Object, ITransitionDetailed>), method);
                    _Methods.Add((Func<Object, ITransitionDetailed>)func);
                }
                catch (Exception exception)
                {
                    Debug.LogError(
                        $"Failed to create delegate for" +
                        $" {method.DeclaringType.GetNameCS()}.{method.Name}," +
                        $" it must take one {typeof(Object).FullName} parameter" +
                        $" and return {typeof(ITransition).FullName}" +
                        $": {exception}");
                }
            }
        }

        /************************************************************************************************************************/

        /// <summary>[Editor-Only] Tries to create an asset containing an appropriate transition for the `target`.</summary>
        public static TransitionAssetBase TryCreateTransitionAsset(Object target)
        {
            if (target is TransitionAssetBase asset)
                return asset;

            var assetType = TransitionAssetBase.CreateInstance;
            if (assetType == null)
                return null;

            InitializeMethods();

            for (int i = 0; i < _Methods.Count; i++)
            {
                var transition = _Methods[i](target);
                if (transition is not null)
                {
                    var created = TransitionAssetBase.CreateInstance(transition);
                    created.name = target.name;
                    return created;
                }
            }

            return null;
        }

        /************************************************************************************************************************/
#endif
        /************************************************************************************************************************/
    }
}

