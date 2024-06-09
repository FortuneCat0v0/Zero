namespace ET
{
    public class ActionEventAttribute : BaseAttribute
    {
    }

    [ActionEvent]
    public abstract class AActionEvent : HandlerObject
    {
        public abstract bool Check(Skill skill);

        /// <summary>
        /// 成功 Skill.NextActionEventIndex + 1,失败 Skill.EndSpell
        /// 若改阶段对后段技能有影响，例如：盲僧的Q，Q到敌人才有第二段，没Q到就直接Skill.EndSpell
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract ETTask Execute(Skill skill, ETCancellationToken cancellationToken);
    }
}