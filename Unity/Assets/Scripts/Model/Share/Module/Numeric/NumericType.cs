using System.Collections.Generic;

namespace ET
{
    public static class NumericType
    {
        [StaticField]
        public static List<int> Broadcast = new() { Speed, Hp, MaxHp };

        [StaticField]
        public static List<int> Percent = new() { Dodge };

        public const int Max = 10000;

        public const int AttackDamage = 1001; //攻击力
        public const int AttackDamageBase = AttackDamage * 10 + 1;
        public const int AttackDamageAdd = AttackDamage * 10 + 2;
        public const int AttackDamagePct = AttackDamage * 10 + 3;
        public const int AttackDamageFinalAdd = AttackDamage * 10 + 4;
        public const int AttackDamageFinalPct = AttackDamage * 10 + 5;

        public const int AbilityPower = 1002; //法术强度
        public const int AbilityPowerBase = AbilityPower * 10 + 1;
        public const int AbilityPowerAdd = AbilityPower * 10 + 2;
        public const int AbilityPowerPct = AbilityPower * 10 + 3;
        public const int AbilityPowerFinalAdd = AbilityPower * 10 + 4;
        public const int AbilityPowerFinalPct = AbilityPower * 10 + 5;

        public const int AttackSpeed = 1003; //攻击速度
        public const int AttackSpeedBase = AttackSpeed * 10 + 1;
        public const int AttackSpeedAdd = AttackSpeed * 10 + 2;
        public const int AttackSpeedPct = AttackSpeed * 10 + 3;
        public const int AttackSpeedFinalAdd = AttackSpeed * 10 + 4;
        public const int AttackSpeedFinalPct = AttackSpeed * 10 + 5;

        public const int CriticalStrikeChance = 1004; //暴击几率
        public const int CriticalStrikeChanceBase = CriticalStrikeChance * 10 + 1;
        public const int CriticalStrikeChanceAdd = CriticalStrikeChance * 10 + 2;
        public const int CriticalStrikeChancePct = CriticalStrikeChance * 10 + 3;
        public const int CriticalStrikeChanceFinalAdd = CriticalStrikeChance * 10 + 4;
        public const int CriticalStrikeChanceFinalPct = CriticalStrikeChance * 10 + 5;

        public const int CriticalStrikeDamage = 1005; //暴击伤害
        public const int CriticalStrikeDamageBase = CriticalStrikeDamage * 10 + 1;
        public const int CriticalStrikeDamageAdd = CriticalStrikeDamage * 10 + 2;
        public const int CriticalStrikeDamagePct = CriticalStrikeDamage * 10 + 3;
        public const int CriticalStrikeDamageFinalAdd = CriticalStrikeDamage * 10 + 4;
        public const int CriticalStrikeDamageFinalPct = CriticalStrikeDamage * 10 + 5;

        public const int ArmorPenetration = 1006; //护甲穿透
        public const int ArmorPenetrationBase = ArmorPenetration * 10 + 1;
        public const int ArmorPenetrationAdd = ArmorPenetration * 10 + 2;
        public const int ArmorPenetrationPct = ArmorPenetration * 10 + 3;
        public const int ArmorPenetrationFinalAdd = ArmorPenetration * 10 + 4;
        public const int ArmorPenetrationFinalPct = ArmorPenetration * 10 + 5;

        public const int MagicPenetration = 1007; //法术穿透
        public const int MagicPenetrationBase = MagicPenetration * 10 + 1;
        public const int MagicPenetrationAdd = MagicPenetration * 10 + 2;
        public const int MagicPenetrationPct = MagicPenetration * 10 + 3;
        public const int MagicPenetrationFinalAdd = MagicPenetration * 10 + 4;
        public const int MagicPenetrationFinalPct = MagicPenetration * 10 + 5;

        public const int LifeSteal = 1008; //生命偷取
        public const int LifeStealBase = LifeSteal * 10 + 1;
        public const int LifeStealAdd = LifeSteal * 10 + 2;
        public const int LifeStealPct = LifeSteal * 10 + 3;
        public const int LifeStealFinalAdd = LifeSteal * 10 + 4;
        public const int LifeStealFinalPct = LifeSteal * 10 + 5;

        public const int SpellVamp = 1009; //法术吸血
        public const int SpellVampBase = SpellVamp * 10 + 1;
        public const int SpellVampAdd = SpellVamp * 10 + 2;
        public const int SpellVampPct = SpellVamp * 10 + 3;
        public const int SpellVampFinalAdd = SpellVamp * 10 + 4;
        public const int SpellVampFinalPct = SpellVamp * 10 + 5;

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

        public const int Armor = 1013; //护甲
        public const int ArmorBase = Armor * 10 + 1;
        public const int ArmorAdd = Armor * 10 + 2;
        public const int ArmorPct = Armor * 10 + 3;
        public const int ArmorFinalAdd = Armor * 10 + 4;
        public const int ArmorFinalPct = Armor * 10 + 5;

        public const int MagicResist = 1014; //魔法抗性
        public const int MagicResistBase = MagicResist * 10 + 1;
        public const int MagicResistAdd = MagicResist * 10 + 2;
        public const int MagicResistPct = MagicResist * 10 + 3;
        public const int MagicResistFinalAdd = MagicResist * 10 + 4;
        public const int MagicResistFinalPct = MagicResist * 10 + 5;

        public const int Tenacity = 1015; //韧性
        public const int TenacityBase = Tenacity * 10 + 1;
        public const int TenacityAdd = Tenacity * 10 + 2;
        public const int TenacityPct = Tenacity * 10 + 3;
        public const int TenacityFinalAdd = Tenacity * 10 + 4;
        public const int TenacityFinalPct = Tenacity * 10 + 5;

        public const int Dodge = 1016; //闪避
        public const int DodgeBase = Dodge * 10 + 1;
        public const int DodgeAdd = Dodge * 10 + 2;
        public const int DodgePct = Dodge * 10 + 3;
        public const int DodgeFinalAdd = Dodge * 10 + 4;
        public const int DodgeFinalPct = Dodge * 10 + 5;

        public const int Speed = 1017;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int CooldownReduction = 1018; //冷却缩减
        public const int CooldownReductionBase = CooldownReduction * 10 + 1;
        public const int CooldownReductionAdd = CooldownReduction * 10 + 2;
        public const int CooldownReductionPct = CooldownReduction * 10 + 3;
        public const int CooldownReductionFinalAdd = CooldownReduction * 10 + 4;
        public const int CooldownReductionFinalPct = CooldownReduction * 10 + 5;

        public const int Mana = 1019; //法力值
        public const int ManaBase = Mana * 10 + 1;
        public const int ManaAdd = Mana * 10 + 2;
        public const int ManaPct = Mana * 10 + 3;
        public const int ManaFinalAdd = Mana * 10 + 4;
        public const int ManaFinalPct = Mana * 10 + 5;

        public const int ManaRegeneration = 1020; //法力回复
        public const int ManaRegenerationBase = ManaRegeneration * 10 + 1;
        public const int ManaRegenerationAdd = ManaRegeneration * 10 + 2;
        public const int ManaRegenerationPct = ManaRegeneration * 10 + 3;
        public const int ManaRegenerationFinalAdd = ManaRegeneration * 10 + 4;
        public const int ManaRegenerationFinalPct = ManaRegeneration * 10 + 5;

        public const int Energy = 1021; //能量
        public const int EnergyBase = Energy * 10 + 1;
        public const int EnergyAdd = Energy * 10 + 2;
        public const int EnergyPct = Energy * 10 + 3;
        public const int EnergyFinalAdd = Energy * 10 + 4;
        public const int EnergyFinalPct = Energy * 10 + 5;

        public const int EnergyRegeneration = 1022; //能量回复
        public const int EnergyRegenerationBase = EnergyRegeneration * 10 + 1;
        public const int EnergyRegenerationAdd = EnergyRegeneration * 10 + 2;
        public const int EnergyRegenerationPct = EnergyRegeneration * 10 + 3;
        public const int EnergyRegenerationFinalAdd = EnergyRegeneration * 10 + 4;
        public const int EnergyRegenerationFinalPct = EnergyRegeneration * 10 + 5;

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
        public const int BulletRadius = 2001; //子弹半径
        public const int BulletLife = 2002; //子弹周期
        public const int RideState = 2003; //骑乘状态 0未骑乘 1骑乘中
    }
}