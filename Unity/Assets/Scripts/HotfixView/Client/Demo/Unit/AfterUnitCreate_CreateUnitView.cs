using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_CreateUnitView : AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            Unit unit = args.Unit;

            // Unit View层

            if (unit.UnitType == EUnitType.Player)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("AngelSlime").GameObject;
                unit.AddComponent<AnimationComponent>().UpdateAnimData(model);

                unit.AddComponent<UnitTransformComponent>();

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, Transform>(model.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.UnitType == EUnitType.Monster)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("PowerSlime").GameObject;
                unit.AddComponent<AnimationComponent>().UpdateAnimData(model);

                unit.AddComponent<UnitTransformComponent>();

                HeadInfosComponent headInfosComponent = unit.AddComponent<HeadInfosComponent, Transform>(model.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                headInfosComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.UnitType == EUnitType.Skill)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("Bullet").GameObject;
            }

            unit.AddComponent<EffectComponent>();

            // 碰撞体显示
            // CollisionViewComponent collisionViewComponent = unit.AddComponent<CollisionViewComponent, GameObject>(model);
            // UnitConfig unitConfig = UnitConfigCategory.Instance.Get(unit.ConfigId);
            //
            // collisionViewComponent.AddColloder(unitConfig.ColliderType, new Vector2(unitConfig.ColliderParams[0], 0));

            await ETTask.CompletedTask;
        }
    }
}