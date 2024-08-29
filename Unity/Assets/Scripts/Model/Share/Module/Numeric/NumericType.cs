using System.Collections.Generic;

namespace ET
{
    public static class NumericType
    {
        [StaticField]
        public static List<int> Broadcast = new() { Speed, NowHp, MaxHp };

        [StaticField]
        public static List<int> Percent = new() { };

        public const int MaxHp = 1001; //最大生命值
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        public const int Speed = 1002; //移动速度
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int AttackDamage = 1003; //攻击力
        public const int AttackDamageBase = AttackDamage * 10 + 1;
        public const int AttackDamageAdd = AttackDamage * 10 + 2;
        public const int AttackDamagePct = AttackDamage * 10 + 3;
        public const int AttackDamageFinalAdd = AttackDamage * 10 + 4;
        public const int AttackDamageFinalPct = AttackDamage * 10 + 5;

        public const int ________ = 3000; //小于此值的类型是通过公式计算得出的结果，不可以直接修改

        public const int NowHp = 3001; //生命值
        public const int AOI = 3002;

        public const int RechargeAmount = 8001; //充值金额
        public const int Gold = 8010; //金块
        public const int Silk = 8011; //丝绸

        public const int Max = 10000;
    }
}