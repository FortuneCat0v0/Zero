using System.Collections.Generic;

namespace ET
{
    public static class NumericType
    {
        [StaticField]
        public static List<int> Broadcast = new() { Speed, Hp, MaxHp };

        [StaticField]
        public static List<int> Percent = new() { Dodge, CriticalHitRate };

        public const int Max = 10000;

        public const int Speed = 1000;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int Hp = 1001;

        public const int MaxHp = 1002;
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        public const int AOI = 1003;

        public const int MaxMp = 1004;
        public const int MaxMpBase = MaxMp * 10 + 1;
        public const int MaxMpAdd = MaxMp * 10 + 2;
        public const int MaxMpPct = MaxMp * 10 + 3;
        public const int MaxMpFinalAdd = MaxMp * 10 + 4;
        public const int MaxMpFinalPct = MaxMp * 10 + 5;

        public const int DamageValue = 1011; //伤害
        public const int DamageValueBase = DamageValue * 10 + 1;
        public const int DamageValueAdd = DamageValue * 10 + 2;
        public const int DamageValuePct = DamageValue * 10 + 3;
        public const int DamageValueFinalAdd = DamageValue * 10 + 4;
        public const int DamageValueFinalPct = DamageValue * 10 + 5;

        public const int MP = 1014; //法力值

        public const int MaxMP = 1014; //法力值上限
        public const int MaxMPBase = MaxMP * 10 + 1;
        public const int MaxMPAdd = MaxMP * 10 + 2;
        public const int MaxMPPct = MaxMP * 10 + 3;
        public const int MaxMPFinalAdd = MaxMP * 10 + 4;
        public const int MaxMPFinalPct = MaxMP * 10 + 5;

        public const int Armor = 1015; //护甲
        public const int ArmorBase = Armor * 10 + 1;
        public const int ArmorAdd = Armor * 10 + 2;
        public const int ArmorPct = Armor * 10 + 3;
        public const int ArmorFinalAdd = Armor * 10 + 4;
        public const int ArmorFinalPct = Armor * 10 + 5;

        public const int Dodge = 1017; //闪避
        public const int DodgeBase = Dodge * 10 + 1;
        public const int DodgeAdd = Dodge * 10 + 2;
        public const int DodgePct = Dodge * 10 + 3;
        public const int DodgeFinalAdd = Dodge * 10 + 4;
        public const int DodgeFinalPct = Dodge * 10 + 5;

        public const int CriticalHitRate = 1019; //暴击率
        public const int CriticalHitRateBase = CriticalHitRate * 10 + 1;
        public const int CriticalHitRateAdd = CriticalHitRate * 10 + 2;
        public const int CriticalHitRatePct = CriticalHitRate * 10 + 3;
        public const int CriticalHitRateFinalAdd = CriticalHitRate * 10 + 4;
        public const int CriticalHitRateFinalPct = CriticalHitRate * 10 + 5;

        public const int Fortune = 1014; //时运
        public const int FortuneBase = Fortune * 10 + 1;
        public const int FortuneAdd = Fortune * 10 + 2;
        public const int FortunePct = Fortune * 10 + 3;
        public const int FortuneFinalAdd = Fortune * 10 + 4;
        public const int FortuneFinalPct = Fortune * 10 + 5;

        //////////子弹属性相关//////////////
        public const int BulletRadius = 1101; //子弹半径
        public const int BulletLife = 1101; //子弹周期
    }
}