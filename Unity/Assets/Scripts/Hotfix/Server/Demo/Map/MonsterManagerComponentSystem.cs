using System;
using Unity.Mathematics;

namespace ET.Server
{
    [Invoke(TimerInvokeType.RefreshMonsterInMap)]
    public class RefreshMonsterInMap : ATimer<MonsterManagerComponent>
    {
        protected override void Run(MonsterManagerComponent self)
        {
            try
            {
                self.RefreshMonster();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(MonsterManagerComponent))]
    [EntitySystemOf(typeof(MonsterManagerComponent))]
    public static partial class MonsterManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MonsterManagerComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(10000, TimerInvokeType.RefreshMonsterInMap, self);
        }

        [EntitySystem]
        private static void Destroy(this MonsterManagerComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void RefreshMonster(this MonsterManagerComponent self)
        {
            int monsterCount = 0;

            foreach (Unit unit in self.Root().GetComponent<UnitComponent>().GetAll())
            {
                if (unit.UnitType != EUnitType.Monster)
                {
                    continue;
                }

                monsterCount++;
            }

            for (int i = monsterCount; i < 5; i++)
            {
                UnitFactory.CreateMonster(self.Root(), new float3(i * 1.5f, 0, 0));
            }
        }
    }
}