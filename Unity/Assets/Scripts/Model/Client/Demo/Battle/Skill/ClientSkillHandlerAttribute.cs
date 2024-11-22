namespace ET.Client
{
    public class ClientSkillHandlerAttribute : BaseAttribute
    {
    }

    /// <summary>
    /// Skill能调用Handler的方法，Handler不能调用Skill的方法
    /// </summary>
    [ClientSkillHandler]
    public abstract class ClientSkillHandler : HandlerObject
    {
        public abstract void OnInit(ClientSkill clientSkill);

        public abstract void OnUpdate(ClientSkill clientSkill);

        public abstract void OnFinish(ClientSkill clientSkill);
    }
}