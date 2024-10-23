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
                model.transform.position = unit.Position;
                unit.AddComponent<AnimationComponent>().UpdateAnimData(model);

                unit.AddComponent<UnitTransformComponent>();

                UIHeadInfoComponent uiHeadInfoComponent = unit.AddComponent<UIHeadInfoComponent, Transform>(model.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                uiHeadInfoComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.NowHp) * 1f /
                    numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.UnitType == EUnitType.Monster)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("PowerSlime").GameObject;
                model.transform.position = unit.Position;
                unit.AddComponent<AnimationComponent>().UpdateAnimData(model);

                unit.AddComponent<UnitTransformComponent>();

                UIHeadInfoComponent uiHeadInfoComponent = unit.AddComponent<UIHeadInfoComponent, Transform>(model.transform);
                NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                uiHeadInfoComponent.RefreshHealthBar(numericComponent.GetAsInt(NumericType.NowHp) * 1f /
                    numericComponent.GetAsInt(NumericType.MaxHp));
            }
            else if (unit.UnitType == EUnitType.Item)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("Item").GameObject;
                model.transform.position = unit.Position;
            }
            else if (unit.UnitType == EUnitType.Skill)
            {
                GameObject model = unit.AddComponent<GameObjectComponent, string>("Bullet").GameObject;
                model.transform.position = unit.Position;
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