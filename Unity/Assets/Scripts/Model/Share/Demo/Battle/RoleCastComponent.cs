namespace ET
{
    public enum ERoleCast
    {
        Friendly, //友善
        Adverse, //敌对
        Neutral //中立
    }

    [System.Flags]
    public enum ERoleCamp
    {
        Player = 0b0000001,
        Monster = 0b0000010,
        red = 0b0000100,
        bule = 0b0001000,
        yellow = 0b0010000,
        green = 0b0100000,
        JunHeng = 0b1000000
    }

    public enum ERoleTag
    {
        Sprite,
        AttackRange,
        NoCollision,
        Hero,
        Map,
        Creeps,
        SkillCollision,
    }

    [ComponentOf(typeof(Unit))]
    public class RoleCastComponent : Entity, IAwake<ERoleCamp, ERoleTag>, ITransfer
    {
        /// <summary>
        /// 归属阵营
        /// </summary>
        public ERoleCamp RoleCamp { get; set; }

        public ERoleTag RoleTag { get; set; }
    }
}