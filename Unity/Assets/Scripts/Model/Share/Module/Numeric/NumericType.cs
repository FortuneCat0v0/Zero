using System.Collections.Generic;

namespace ET
{
    public static class NumericType
    {
        [StaticField]
        public static List<int> Broadcast = new() { Speed, Hp, MaxHp };

        [StaticField]
        public static List<int> Percent = new() { };

        public const int Max = 10000;

        public const int AttackDamage = 1001; //攻击力
        public const int AttackDamageBase = AttackDamage * 10 + 1;
        public const int AttackDamageAdd = AttackDamage * 10 + 2;
        public const int AttackDamagePct = AttackDamage * 10 + 3;
        public const int AttackDamageFinalAdd = AttackDamage * 10 + 4;
        public const int AttackDamageFinalPct = AttackDamage * 10 + 5;

        public const int Hp = 1010; //生命值

        public const int MaxHp = 1011; //最大生命值
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        public const int HealthRegeneration = 1012; //生命回复
        public const int HealthRegenerationBase = HealthRegeneration * 10 + 1;
        public const int HealthRegenerationAdd = HealthRegeneration * 10 + 2;
        public const int HealthRegenerationPct = HealthRegeneration * 10 + 3;
        public const int HealthRegenerationFinalAdd = HealthRegeneration * 10 + 4;
        public const int HealthRegenerationFinalPct = HealthRegeneration * 10 + 5;

        public const int Speed = 1017;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int Fortune = 1023; //时运
        public const int FortuneBase = Fortune * 10 + 1;
        public const int FortuneAdd = Fortune * 10 + 2;
        public const int FortunePct = Fortune * 10 + 3;
        public const int FortuneFinalAdd = Fortune * 10 + 4;
        public const int FortuneFinalPct = Fortune * 10 + 5;

        public const int Androgen = 1024; //雄性激素 促进战斗能力提升
        public const int AndrogenBase = Androgen * 10 + 1;
        public const int AndrogenAdd = Androgen * 10 + 2;
        public const int AndrogenPct = Androgen * 10 + 3;
        public const int AndrogenFinalAdd = Androgen * 10 + 4;
        public const int AndrogenFinalPct = Androgen * 10 + 5;

        public const int Estrogen = 1025; //雌性激素 促进繁殖
        public const int EstrogenBase = Estrogen * 10 + 1;
        public const int EstrogenAdd = Estrogen * 10 + 2;
        public const int EstrogenPct = Estrogen * 10 + 3;
        public const int EstrogenFinalAdd = Estrogen * 10 + 4;
        public const int EstrogenFinalPct = Estrogen * 10 + 5;

        public const int AOI = 2000;
    }
}