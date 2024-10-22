namespace ET.Server
{
    public class AIHandlerAttribute : BaseAttribute
    {
    }

    [AIHandler]
    public abstract class AAIHandler : HandlerObject
    {
        /// <summary>
        /// 返回 0继续执行 1执行下一个行为
        /// </summary>
        /// <param name="aiComponent"></param>
        /// <param name="aiConfig"></param>
        /// <returns></returns>
        public abstract int Check(AIComponent aiComponent, AIConfig aiConfig);

        // 协程编写必须可以取消
        public abstract ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken);
    }
}