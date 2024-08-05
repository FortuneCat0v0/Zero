using System;

namespace ET
{
    [Flags]
    public enum StateType
    {
        /// <summary>
        /// 空闲
        /// </summary>
        None = 1 << 1,

        /// <summary>
        /// 行走
        /// </summary>
        Run = 1 << 2,

        /// <summary>
        /// 释放技能
        /// </summary>
        SkillCast = 1 << 3,

        /// <summary>
        /// 普攻
        /// </summary>
        CommonAttack = 1 << 4,

        /// <summary>
        /// 击退
        /// </summary>
        RePluse = 1 << 5,

        /// <summary>
        /// 沉默
        /// </summary>
        Silence = 1 << 6,

        /// <summary>
        /// 眩晕
        /// </summary>
        Dizziness = 1 << 7,

        /// <summary>
        /// 击飞
        /// </summary>
        Striketofly = 1 << 8,

        /// <summary>
        /// 嘲讽
        /// </summary>
        Sneer = 1 << 9,

        /// <summary>
        /// 无敌
        /// </summary>
        Invincible = 1 << 10,

        /// <summary>
        /// 禁锢
        /// </summary>
        Shackle = 1 << 11,

        /// <summary>
        /// 隐身
        /// </summary>
        Invisible = 1 << 12,

        /// <summary>
        /// 恐惧
        /// </summary>
        Fear = 1 << 13,

        /// <summary>
        /// 致盲
        /// </summary>
        Blind = 1 << 14,

        /// <summary>
        /// 排斥普攻，有此状态无法普攻
        /// </summary>
        CommonAttackConflict = 1 << 15,

        /// <summary>
        /// 排斥行走，有此状态无法行走
        /// </summary>
        WalkConflict = 1 << 16,

        /// <summary>
        /// 排斥释放技能，有此状态无法释放技能
        /// </summary>
        CastSkillConflict = 1 << 17,
    }
}