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
            ResourcesLoaderComponent resourcesLoaderComponent = scene.GetComponent<ResourcesLoaderComponent>();

            // Unit View层
            string assetsName = "Assets/Bundles/Unit/Unit.prefab";
            GameObject bundleGameObject = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(assetsName);
            GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
            GameObject unitParent = UnityEngine.Object.Instantiate(bundleGameObject, globalComponent.Unit, true);
            unitParent.transform.position = unit.Position;
            unitParent.name = EUnitType.Player + "" + unit.Id;

            unit.AddComponent<EffectComponent>();

            ReferenceCollector rc = unitParent.GetComponent<ReferenceCollector>();
            GameObject model;
            if (unit.Type() == EUnitType.Player)
            {
                assetsName = $"Assets/Bundles/Unit/AngelSlime.prefab";
                bundleGameObject = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(assetsName);

                model = UnityEngine.Object.Instantiate(bundleGameObject, unitParent.transform, true);
                model.transform.localPosition = Vector3.zero;
                unit.AddComponent<GameObjectComponent>().GameObject = unitParent;
                unit.AddComponent<AnimatorComponent>();

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, GameObject>(rc.Get<GameObject>("HeadInfos"));
                headInfosComponent.Transform.gameObject.SetActive(true);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.Type() == EUnitType.Monster)
            {
                assetsName = $"Assets/Bundles/Unit/PowerSlime.prefab";
                bundleGameObject = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(assetsName);

                model = UnityEngine.Object.Instantiate(bundleGameObject, unitParent.transform, true);
                model.transform.localPosition = Vector3.zero;
                unit.AddComponent<GameObjectComponent>().GameObject = unitParent;

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, GameObject>(rc.Get<GameObject>("HeadInfos"));
                headInfosComponent.Transform.gameObject.SetActive(true);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.Type() == EUnitType.Bullet)
            {
                assetsName = $"Assets/Bundles/Unit/Bullet.prefab";
                bundleGameObject = await resourcesLoaderComponent.LoadAssetAsync<GameObject>(assetsName);

                model = UnityEngine.Object.Instantiate(bundleGameObject, unitParent.transform, true);
                model.transform.localPosition = Vector3.zero;
                unit.AddComponent<GameObjectComponent>().GameObject = unitParent;
            }
            else
            {
                return;
            }

#if UNITY_EDITOR

            // 碰撞体显示
            CollisionViewComponent collisionViewComponent = unit.AddComponent<CollisionViewComponent, GameObject>(model);
            UnitConfig unitConfig = UnitConfigCategory.Instance.Get(unit.ConfigId);

            collisionViewComponent.AddColloder(unitConfig.ColliderType, new Vector2(unitConfig.ColliderParams[0], 0));
#endif

            await ETTask.CompletedTask;
        }
    }
}