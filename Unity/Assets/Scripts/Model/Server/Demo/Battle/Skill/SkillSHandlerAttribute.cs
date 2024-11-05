namespace ET.Server
{
    public class SkillSHandlerAttribute : BaseAttribute
    {
    }

    /// <summary>
    /// Skill能调用Handler的方法，Handler不能调用Skill的方法
    /// </summary>
    [SkillSHandler]
    public abstract class SkillSHandler : HandlerObject
    {
        public abstract void OnInit(SkillS skillS);
        public abstract void OnUpdate(SkillS skillS);
        public abstract void OnFinish(SkillS skillS);
    }
}