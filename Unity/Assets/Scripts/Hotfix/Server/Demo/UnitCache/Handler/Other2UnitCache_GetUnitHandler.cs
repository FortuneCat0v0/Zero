using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(UnitCacheComponent))]
    [MessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_GetUnitHandler : MessageHandler<Scene, Other2UnitCache_GetUnit, UnitCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetUnit request, UnitCache2Other_GetUnit response)
        {
            UnitCacheComponent unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            Dictionary<string, Entity> dict = ObjectPool.Instance.Fetch(typeof(Dictionary<string, Entity>)) as Dictionary<string, Entity>;
            try
            {
                if (request.ComponentNameList.Count == 0)
                {
                    dict.Add("ET.Unit", null);
                    foreach (string s in unitCacheComponent.UnitCacheKeys)
                    {
                        if (s == "ET.Unit")
                        {
                            continue;
                        }

                        dict.Add(s, null);
                    }
                }
                else
                {
                    foreach (string s in request.ComponentNameList)
                    {
                        dict.Add(s, null);
                    }
                }

                using (await scene.GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnitCacheGet, request.UnitId))
                {
                    unitCacheComponent.CallCache(request.UnitId);

                    using (ListComponent<string> keyList = ListComponent<string>.Create())
                    {
                        foreach (var key in dict.Keys)
                        {
                            keyList.Add(key);
                        }

                        foreach (var key in keyList)
                        {
                            Entity entity = await unitCacheComponent.Get(request.UnitId, key);
                            dict[key] = entity;
                        }
                    }

                    foreach (var info in dict)
                    {
                        response.ComponentNameList.Add(info.Key);
                        response.EntityList.Add(info.Value?.ToBson() ?? null);
                    }
                }
            }
            finally
            {
                dict.Clear();
                ObjectPool.Instance.Recycle(dict);
            }

            await ETTask.CompletedTask;
        }
    }
}