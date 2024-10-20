namespace ET.Server
{
    [FriendOf(typeof(UnitCacheComponent))]
    [MessageHandler(SceneType.UnitCache)]
    public class Other2UnitCache_AddOrUpdateUnitHandler : MessageHandler<Scene, Other2UnitCache_AddOrUpdateUnit, UnitCache2Other_AddOrUpdateUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            UpdateUnitCacheAsync(scene, request, response).Coroutine();
            await ETTask.CompletedTask;
        }

        private async ETTask UpdateUnitCacheAsync(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            UnitCacheComponent unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            using (ListComponent<Entity> entityList = ListComponent<Entity>.Create())
            {
                for (int index = 0; index < request.EntityTypes.Count; ++index)
                {
                    Entity entity = MongoHelper.Deserialize<Entity>(request.EntityBytes[index]);
                    entityList.Add(entity);
                }

                await unitCacheComponent.AddOrUpdate(request.UnitId, entityList);
            }
        }
    }
}