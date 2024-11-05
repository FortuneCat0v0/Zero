namespace ET.Client
{
    public class SkillCHandlerAttribute : BaseAttribute
    {
    }

    /// <summary>
    /// Skill能调用Handler的方法，Handler不能调用Skill的方法
    /// </summary>
    [SkillCHandler]
    public abstract class SkillCHandler : HandlerObject
    {
        public abstract void OnInit(SkillC skillC);

        public abstract void OnUpdate(SkillC skillC);

        public abstract void OnFinish(SkillC skillC);
    }
}