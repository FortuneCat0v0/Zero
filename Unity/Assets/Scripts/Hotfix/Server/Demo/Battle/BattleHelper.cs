using System.Collections;
using System.Collections.Generic;

namespace ET.Server
{
    public static class BattleHelper
    {
        public static void HitSettle(Unit from, Unit to, EHitFromType hitType, int damage = 0)
        {
            switch (hitType)
            {
                case EHitFromType.Skill_Normal:
                {
                    int dmg = damage;
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                    to.GetComponent<NumericComponent>().Set(NumericType.Hp, finalHp);
                    if (finalHp <= 0)
                    {
                        // 死亡发事件通知
                    }

                    Log.Info($"hit settle, from:{from?.Id}, to:{to?.Id}, value:{dmg}");

                    EventSystem.Instance.Publish(from.Root(),
                        new HitResult() { FromUnit = from, ToUnit = to, HitResultType = EHitResultType.Damage, Value = dmg });
                    break;
                }
                case EHitFromType.Skill_Bullet:
                {
                    int dmg = from.GetComponent<NumericComponent>().GetAsInt(NumericType.Attack);
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                    to.GetComponent<NumericComponent>().Set(NumericType.Hp, finalHp);
                    if (finalHp <= 0)
                    {
                        // 死亡发事件通知
                    }

                    Log.Info($"hit settle, from:{from.Id}, to:{to.Id}, value:{dmg}");

                    EventSystem.Instance.Publish(from.Root(),
                        new HitResult() { FromUnit = from, ToUnit = to, HitResultType = EHitResultType.Damage, Value = dmg });
                    break;
                }
            }
        }
    }
}