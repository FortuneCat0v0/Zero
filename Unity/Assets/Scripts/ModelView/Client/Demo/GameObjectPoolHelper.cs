using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectPoolHelper
    {
        [StaticField]
        private static Dictionary<string, GameObjectPool> poolDict = new();

        public static GameObject GetObjectFromPool(Scene scene, string poolName, bool autoActive = true, int size = 3,
        PoolInflationType type = PoolInflationType.INCREMENT)
        {
            GameObject result = null;

            if (!poolDict.ContainsKey(poolName) && size > 0)
            {
                try
                {
                    GameObject pb = GetGameObject(scene, poolName);
                    if (pb == null)
                    {
                        Debug.LogError("[ResourceManager] Invalide prefab name for pooling :" + poolName);
                    }

                    poolDict[poolName] = new GameObjectPool(poolName, pb, GameObject.Find("Global/PoolRoot"), size, type);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }

            if (poolDict.ContainsKey(poolName))
            {
                GameObjectPool pool = poolDict[poolName];
                result = pool.NextAvailableObject(autoActive);
                //scenario when no available object is found in pool
#if UNITY_EDITOR
                if (result == null)
                {
                    Debug.LogWarning("[ResourceManager]:No object available in " + poolName);
                }
#endif
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogError("[ResourceManager]:Invalid pool name specified: " + poolName);
            }
#endif
            return result;
        }

        public static void ReturnObjectToPool(GameObject go)
        {
            PoolObject po = go.GetComponent<PoolObject>();
            if (po == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Specified object is not a pooled instance: " + go.name);
#endif
            }
            else
            {
                GameObjectPool pool = null;
                if (poolDict.TryGetValue(po.poolName, out pool))
                {
                    pool.ReturnObjectToPool(po);
                }
#if UNITY_EDITOR
                else
                {
                    Debug.LogWarning("No pool available with name: " + po.poolName);
                }
#endif
            }
        }

        private static GameObject GetGameObject(Scene scene, string poolName)
        {
            GameObject pb = scene.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(poolName);
            return pb;
        }
    }
}