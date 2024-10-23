using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectPoolHelper
    {
        [StaticField]
        private static Dictionary<string, GameObjectPool> poolDict = new();

        public static GameObject GetObjectFromPoolSync(Scene scene, string poolName, bool autoActive = true, int size = 3,
        PoolInflationType type = PoolInflationType.INCREMENT)
        {
            GameObject result = null;

            if (!poolDict.ContainsKey(poolName) && size > 0)
            {
                try
                {
                    GameObject pb = GetGameObjectSync(scene, poolName);
                    if (pb == null)
                    {
                        Log.Error("[ResourceManager] Invalide prefab name for pooling :" + poolName);
                    }

                    poolDict[poolName] = new GameObjectPool(poolName, pb, GameObject.Find("Global/PoolRoot"), size, type);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }

            if (poolDict.ContainsKey(poolName))
            {
                GameObjectPool pool = poolDict[poolName];
                result = pool.NextAvailableObject(autoActive);
                //scenario when no available object is found in pool

                if (result == null)
                {
                    Log.Warning("[ResourceManager]:No object available in " + poolName);
                }
            }
            else
            {
                Log.Error("[ResourceManager]:Invalid pool name specified: " + poolName);
            }

            return result;
        }

        public static async ETTask<GameObject> GetObjectFromPoolAsync(Scene scene, string poolName, bool autoActive = true, int size = 3,
        PoolInflationType type = PoolInflationType.INCREMENT)
        {
            GameObject result = null;

            if (!poolDict.ContainsKey(poolName) && size > 0)
            {
                try
                {
                    GameObject pb = await GetGameObjectAsync(scene, poolName);
                    if (pb == null)
                    {
                        Log.Error("[ResourceManager] Invalide prefab name for pooling :" + poolName);
                    }

                    poolDict[poolName] = new GameObjectPool(poolName, pb, GameObject.Find("Global/PoolRoot"), size, type);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }

            if (poolDict.ContainsKey(poolName))
            {
                GameObjectPool pool = poolDict[poolName];
                result = pool.NextAvailableObject(autoActive);
                //scenario when no available object is found in pool

                if (result == null)
                {
                    Log.Warning("[ResourceManager]:No object available in " + poolName);
                }
            }
            else
            {
                Log.Error("[ResourceManager]:Invalid pool name specified: " + poolName);
            }

            return result;
        }

        public static void ReturnObjectToPool(GameObject go)
        {
            PoolObject po = go.GetComponent<PoolObject>();
            if (po == null)
            {
                Log.Warning("Specified object is not a pooled instance: " + go.name);
            }
            else
            {
                GameObjectPool pool = null;
                if (poolDict.TryGetValue(po.poolName, out pool))
                {
                    pool.ReturnObjectToPool(po);
                }
                else
                {
                    Log.Warning("No pool available with name: " + po.poolName);
                }
            }
        }

        private static GameObject GetGameObjectSync(Scene scene, string poolName)
        {
            GameObject go = scene.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(poolName);
            return go;
        }

        private static async ETTask<GameObject> GetGameObjectAsync(Scene scene, string poolName)
        {
            GameObject pb = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(poolName);
            return pb;
        }

        public static void InitPoolFormGamObject(string poolName, GameObject pb, int size = 3, PoolInflationType type = PoolInflationType.INCREMENT)
        {
            if (poolDict.ContainsKey(poolName))
            {
                return;
            }
            else
            {
                try
                {
                    if (pb == null)
                    {
                        Log.Error("[ResourceManager] Invalid prefab name for pooling :" + poolName);
                        return;
                    }

                    poolDict[poolName] = new GameObjectPool(poolName, pb, GameObject.Find("Global/PoolRoot"), size, type);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }
    }
}