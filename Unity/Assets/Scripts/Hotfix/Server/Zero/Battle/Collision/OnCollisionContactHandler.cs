using Box2DSharp.Dynamics.Contacts;

namespace ET.Server
{
    [Event(SceneType.Map)]
    [FriendOf(typeof(BulletComponent))]
    public class OnCollisionContactHandler : AEvent<Scene, OnCollisionContact>
    {
        protected override async ETTask Run(Scene scene, OnCollisionContact args)
        {
            Unit unitA = (Unit)args.contact.FixtureA.UserData;
            Unit unitB = (Unit)args.contact.FixtureB.UserData;
            if (unitA.IsDisposed || unitB.IsDisposed)
            {
                return;
            }

            Log.Info($"start contact:{unitA.Config().Name}, {unitB.Config().Name}");
            EUnitType aType = unitA.Type();
            EUnitType bType = unitB.Type();

            // 当前子弹只处理子弹伤害，子弹回血（给队友回血/技能吸血自行拓展）
            if (aType == EUnitType.Bullet && bType == EUnitType.Player)
            {
                if (unitA.GetComponent<BulletComponent>().OwnerUnit == unitB)
                {
                    return;
                }

                int dmg = unitA.GetComponent<NumericComponent>().GetAsInt(NumericType.Attack);
                int finalHp = unitB.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                if (finalHp <= 0)
                {
                    // 死亡发事件通知
                }

                unitB.GetComponent<NumericComponent>().Set(NumericType.Hp, finalHp, isForcedUpdate: true, isBroadcast: true);

                Log.Info($"hit settle, from:{unitA?.Id}, to:{unitB?.Id}, value:{dmg}");
                EventSystem.Instance.Publish(unitA.Root(), new HitResult() { hitResultType = EHitResultType.Damage, value = dmg });

                // BattleHelper.HitSettle(unitA.GetComponent<BulletComponent>().OwnerUnit, unitB, EHitFromType.Skill_Bullet, unitA);
            }
            // 由于box2d没有双向碰撞响应，处理不同类型的时候判断各自类型
            else if (aType == EUnitType.Player && bType == EUnitType.Bullet)
            {
                if (unitA == unitB.GetComponent<BulletComponent>().OwnerUnit)
                {
                    return;
                }

                int dmg = unitB.GetComponent<NumericComponent>().GetAsInt(NumericType.Attack);
                int finalHp = unitA.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                if (finalHp <= 0)
                {
                    // 死亡发事件通知
                }

                unitA.GetComponent<NumericComponent>().Set(NumericType.Hp, finalHp, isForcedUpdate: true, isBroadcast: true);

                Log.Info($"hit settle, from:{unitA?.Id}, to:{unitB?.Id}, value:{dmg}");
                EventSystem.Instance.Publish(unitA.Root(), new HitResult() { hitResultType = EHitResultType.Damage, value = dmg });

                // BattleHelper.HitSettle(unitA, unitB.GetComponent<BulletComponent>().OwnerUnit, EHitFromType.Skill_Bullet, unitB);
            }
            // 玩家跟玩家碰撞，判定玩家重量大小，大吃小
            else if (aType == EUnitType.Player && bType == EUnitType.Player)
            {
            }
            // 玩家吃到食物
            else if (aType == EUnitType.Player && bType == EUnitType.Food)
            {
                //获取食物的分量，添加给玩家，同时销毁食物单位
            }

            await ETTask.CompletedTask;
        }
    }
}