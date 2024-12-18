
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class SkillConfig : BeanBase
    {
        public SkillConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Level = _buf.ReadInt();
            NextSkill = _buf.ReadInt();
            SkillAbstractType = (SkillAbstractType)_buf.ReadInt();
            Name = _buf.ReadString();
            Desc = _buf.ReadString();
            CD = _buf.ReadInt();
            SkillIndicatorType = (SkillIndicatorType)_buf.ReadInt();
            ColliderParams = ColliderParams.DeserializeColliderParams(_buf);
            CastRange = _buf.ReadFloat();
            SkillHandler = _buf.ReadString();
            EffectConfigId = _buf.ReadInt();
            DmgInterval = _buf.ReadInt();
            Damage = _buf.ReadInt();

            PostInit();
        }

        public static SkillConfig DeserializeSkillConfig(ByteBuf _buf)
        {
            return new SkillConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 技能等级
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// 下一个技能
        /// </summary>
        public readonly int NextSkill;

        /// <summary>
        /// 技能抽象类型
        /// </summary>
        public readonly SkillAbstractType SkillAbstractType;

        /// <summary>
        /// 名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 描述
        /// </summary>
        public readonly string Desc;

        /// <summary>
        /// 冷却时间(毫秒)
        /// </summary>
        public readonly int CD;

        /// <summary>
        /// 技能指示器类型
        /// </summary>
        public readonly SkillIndicatorType SkillIndicatorType;

        /// <summary>
        /// 碰撞体参数
        /// </summary>
        public readonly ColliderParams ColliderParams;

        /// <summary>
        /// 施法范围
        /// </summary>
        public readonly float CastRange;

        /// <summary>
        /// 行为
        /// </summary>
        public readonly string SkillHandler;

        /// <summary>
        /// 特效
        /// </summary>
        public readonly int EffectConfigId;

        /// <summary>
        /// 伤害间隔(毫秒)
        /// </summary>
        public readonly int DmgInterval;

        /// <summary>
        /// 伤害
        /// </summary>
        public readonly int Damage;


        public const int __ID__ = -844226349;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef()
        {
            
            
            
            
            
            
            
            
            ColliderParams?.ResolveRef();
            
            
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Level:" + Level + ","
            + "NextSkill:" + NextSkill + ","
            + "SkillAbstractType:" + SkillAbstractType + ","
            + "Name:" + Name + ","
            + "Desc:" + Desc + ","
            + "CD:" + CD + ","
            + "SkillIndicatorType:" + SkillIndicatorType + ","
            + "ColliderParams:" + ColliderParams + ","
            + "CastRange:" + CastRange + ","
            + "SkillHandler:" + SkillHandler + ","
            + "EffectConfigId:" + EffectConfigId + ","
            + "DmgInterval:" + DmgInterval + ","
            + "Damage:" + Damage + ","
            + "}";
        }

        partial void PostInit();
    }
}
