namespace ET
{
    public class CollisionHandlerAttribute : BaseAttribute
    {
    }

    [CollisionHandler]
    public abstract class CollisionHandler : HandlerObject
    {
        /// <summary>
        /// a是碰撞者自身，b是碰撞到的目标
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public abstract void HandleCollisionStart(Unit a, Unit b);

        /// <summary>
        /// a是碰撞者自身，b是碰撞到的目标
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public abstract void HandleCollisionSustain(Unit a, Unit b);

        /// <summary>
        /// a是碰撞者自身，b是碰撞到的目标
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public abstract void HandleCollisionEnd(Unit a, Unit b);
    }
}