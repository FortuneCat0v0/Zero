using UnityEditor;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView : AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            Unit unit = args.Unit;
            GameObject go;
            // Unit View层
            if (unit.Type() == EUnitType.Player)
            {
                string assetsName = $"Assets/Bundles/Unit/Unit.prefab";
                GameObject bundleGameObject = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
                GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");

                GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
                go = UnityEngine.Object.Instantiate(prefab, globalComponent.Unit, true);
                go.transform.position = unit.Position;
                unit.AddComponent<GameObjectComponent>().GameObject = go;
                unit.AddComponent<AnimatorComponent>();
                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent>();
                await headInfosComponent.Init(go.transform, 0.2f);
            }
            else if (unit.Type() == EUnitType.Bullet)
            {
                string assetsName = $"Assets/Bundles/Unit/Bullet.prefab";
                GameObject bundleGameObject = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

                GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
                go = UnityEngine.Object.Instantiate(bundleGameObject, globalComponent.Unit, true);
                go.transform.position = unit.Position;
                unit.AddComponent<GameObjectComponent>().GameObject = go;
                // unit.AddComponent<AnimatorComponent>();
            }
            else
            {
                return;
            }

#if UNITY_EDITOR

            // 碰撞体显示
            CollisionViewComponent collisionViewComponent = unit.AddComponent<CollisionViewComponent, GameObject>(go);
            UnitConfig unitConfig = UnitConfigCategory.Instance.Get(unit.ConfigId);

            collisionViewComponent.AddColloder(unitConfig.ColliderType, new Vector2(unitConfig.ColliderParams[0], unitConfig.ColliderParams[1]));
#endif

            await ETTask.CompletedTask;
        }
    }
}