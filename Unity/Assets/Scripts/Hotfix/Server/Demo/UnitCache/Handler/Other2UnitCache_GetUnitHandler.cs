using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (UnitCacheComponent))]
    [MessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_GetUnitHandler: MessageHandler<Scene, Other2UnitCache_GetUnit, UnitCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetUnit request, UnitCache2Other_GetUnit response)
        {
            UnitCacheComponent unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            Dictionary<string, byte[]> dictionary = ObjectPool.Instance.Fetch(typeof (Dictionary<string, byte[]>)) as Dictionary<string, byte[]>;
            try
            {
                if (request.ComponentNameList.Count == 0)
                {
                    dictionary.Add(nameof (Unit), null);
                    foreach (string s in unitCacheComponent.UnitCacheKeys)
                    {
                        dictionary.Add(s, null);
                    }
                }
                else
                {
                    foreach (string s in request.ComponentNameList)
                    {
                        dictionary.Add(s, null);
                    }
                }

                foreach (var key in dictionary.Keys)
                {
                    Entity entity = await unitCacheComponent.Get(request.UnitId, key);
                    if (entity != null)
                    {
                        dictionary[key] = entity.ToBson();
                    }
                }

                response.ComponentNameList.AddRange(dictionary.Keys);
                response.EntityList.AddRange(dictionary.Values);
            }
            finally
            {
                dictionary.Clear();
                ObjectPool.Instance.Recycle(dictionary);
            }

            await ETTask.CompletedTask;
        }
    }
}