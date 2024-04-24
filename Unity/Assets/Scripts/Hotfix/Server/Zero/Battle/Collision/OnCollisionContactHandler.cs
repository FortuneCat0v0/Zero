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

            EUnitType aType = unitA.Type();
            EUnitType bType = unitB.Type();

            if (aType == EUnitType.Bullet && bType == EUnitType.Player || aType == EUnitType.Player && bType == EUnitType.Bullet)
            {
                Unit bullet;
                Unit player;

                if (aType == EUnitType.Bullet)
                {
                    bullet = unitA;
                    player = unitB;
                }
                else
                {
                    bullet = unitB;
                    player = unitA;
                }

                if (bullet.GetComponent<BulletComponent>().OwnerUnit == player)
                {
                    return;
                }

                Log.Info($"Start contact:{unitA.Config().Name}, {unitB.Config().Name}");
                BattleHelper.HitSettle(bullet, player, EHitFromType.Skill_Bullet);
            }
            else if (aType == EUnitType.Bullet && bType == EUnitType.Monster || aType == EUnitType.Monster && bType == EUnitType.Bullet)
            {
                Unit bullet;
                Unit monster;

                if (aType == EUnitType.Bullet)
                {
                    bullet = unitA;
                    monster = unitB;
                }
                else
                {
                    bullet = unitB;
                    monster = unitA;
                }

                Log.Info($"Start contact:{unitA.Config().Name}, {unitB.Config().Name}");
                BattleHelper.HitSettle(bullet, monster, EHitFromType.Skill_Bullet);
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