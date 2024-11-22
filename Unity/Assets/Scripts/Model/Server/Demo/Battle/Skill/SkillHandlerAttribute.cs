namespace ET.Server
{
    public class SkillHandlerAttribute : BaseAttribute
    {
    }

    /// <summary>
    /// Skill能调用Handler的方法，Handler不能调用Skill的方法
    /// </summary>
    [SkillHandler]
    public abstract class SkillHandler : HandlerObject
    {
        public abstract void OnInit(Skill skill);
        public abstract void OnUpdate(Skill skill);
        public abstract void OnFinish(Skill skill);
    }
}