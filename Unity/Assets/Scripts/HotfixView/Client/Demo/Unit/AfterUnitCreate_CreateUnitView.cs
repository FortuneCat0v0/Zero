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
            GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
            GameObject unitRoot = GameObjectPoolHelper.GetObjectFromPoolSync(scene, "Assets/Bundles/Unit/Unit.prefab");
            unitRoot.transform.SetParent(globalComponent.Unit);
            unitRoot.transform.position = unit.Position;

            unit.AddComponent<EffectComponent>();
            unit.AddComponent<GameObjectComponent>().UnitGo = unitRoot;

            ReferenceCollector rc = unitRoot.GetComponent<ReferenceCollector>();
            GameObject model;
            if (unit.Type() == EUnitType.Player)
            {
                model = GameObjectPoolHelper.GetObjectFromPoolSync(scene, AssetPathHelper.GetUnitPath("AngelSlime"));
                model.transform.SetParent(unitRoot.transform);
                model.transform.localPosition = Vector3.zero;
                model.transform.localEulerAngles = Vector3.zero;

                unit.GetComponent<GameObjectComponent>().ModelGo = model;
                unit.AddComponent<AnimatorComponent, GameObject>(model);

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, Transform>(unitRoot.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.Type() == EUnitType.Monster)
            {
                model = GameObjectPoolHelper.GetObjectFromPoolSync(scene, AssetPathHelper.GetUnitPath("PowerSlime"));
                model.transform.SetParent(unitRoot.transform);
                model.transform.localPosition = Vector3.zero;
                model.transform.localEulerAngles = Vector3.zero;

                unit.GetComponent<GameObjectComponent>().ModelGo = model;
                unit.AddComponent<AnimatorComponent, GameObject>(model);

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, Transform>(unitRoot.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.Type() == EUnitType.Bullet)
            {
                model = GameObjectPoolHelper.GetObjectFromPoolSync(scene, AssetPathHelper.GetUnitPath("Bullet"));
                model.transform.SetParent(unitRoot.transform);
                model.transform.localPosition = Vector3.zero;
                model.transform.localEulerAngles = Vector3.zero;

                unit.GetComponent<GameObjectComponent>().ModelGo = model;
            }

            // 碰撞体显示
            // CollisionViewComponent collisionViewComponent = unit.AddComponent<CollisionViewComponent, GameObject>(model);
            // UnitConfig unitConfig = UnitConfigCategory.Instance.Get(unit.ConfigId);
            //
            // collisionViewComponent.AddColloder(unitConfig.ColliderType, new Vector2(unitConfig.ColliderParams[0], 0));

            await ETTask.CompletedTask;
        }
    }
}